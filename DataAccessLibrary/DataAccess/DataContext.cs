using Helpers;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using DataModels;

namespace DataAccessLibrary.DataAccess;

public class DataContext : DbContext
{

    public DbSet<BeerModel> Beers => Set<BeerModel>();
    public DbSet<BeerLoverModel> BeerLovers => Set<BeerLoverModel>();
    public DbSet<BeerGroupModel> BeerGroups => Set<BeerGroupModel>();
    public DbSet<RatingModel> Ratings => Set<RatingModel>();
    public DbSet<BreweryModel> Breweries => Set<BreweryModel>();

    readonly JsonDataExtractor extractor;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        extractor = new JsonDataExtractor();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData(modelBuilder).GetAwaiter().GetResult();
    }

    private async Task SeedData(ModelBuilder modelBuilder)
    {
        //Adding the Beerlover data from beerloverdata.json
        List<BeerLoverModel> beerLovers = new();
        List<BeerLoverData> beerLoverData = await extractor.ExtractDataAsync<List<BeerLoverData>>("../BEER/Data/BeerLoverData.json");
        foreach (var beerLover in beerLoverData)
        {
            if (beerLover.ProfilePic != null)
            {
                byte[] imagebyte = await extractor.DownloadImageAsync(beerLover.ProfilePic);
                BeerLoverModel beerLoverToAdd = new() { BeerLoverID = Guid.NewGuid(), BeerLoverName = beerLover.BeerLoverName, BeerLoverEmail = beerLover.BeerLoverEmail, ProfilePic = imagebyte };
                beerLovers.Add(beerLoverToAdd);
            }
            else
            {
                BeerLoverModel beerLoverToAdd = new() { BeerLoverID = Guid.NewGuid(), BeerLoverName = beerLover.BeerLoverName, BeerLoverEmail = beerLover.BeerLoverEmail };
                modelBuilder.Entity<BeerLoverModel>().HasData(beerLoverToAdd);
            }
        }

        //Adding the Beergroup data from beergroupData.json
        List<BeerGroupModel> beerGroups = new();
        List<BeergroupData> beerGroupsData = await extractor.ExtractDataAsync<List<BeergroupData>>("../BEER/Data/BeerGroupdata.json");

        foreach (var group in beerGroupsData)
        {
            if (group.GroupImage != null)
            {
                byte[] imagebyte = await extractor.DownloadImageAsync(group.GroupImage);
                BeerGroupModel beerGroupToAdd = new() { BeerGroupID = Guid.NewGuid(), GroupName = group.GroupName, GroupImage = imagebyte };
                beerGroups.Add(beerGroupToAdd);
            }
            else
            {
                BeerGroupModel beerGroupToAdd = new() { BeerGroupID = Guid.NewGuid(), GroupName = group.GroupName };
                modelBuilder.Entity<BeerGroupModel>().HasData(beerGroupToAdd);
            }
        }
        //Adding the Brewery data from brewerydata.json 
        List<BreweryModel> breweriesData = await extractor.ExtractDataAsync<List<BreweryModel>>("../BEER/Data/Brewerydata.json");

        foreach (var brewery in breweriesData)
        {
            // Generate GUID dynamically
            brewery.BreweryID = Guid.NewGuid();
            // Configure with modelBuilder
            modelBuilder.Entity<BreweryModel>().HasData(brewery);
        };

        //Adding the beer data from beerdata.json 
        List<BeerModel> beers = new();
        List<BeerData> beerData = await extractor.ExtractDataAsync<List<BeerData>>("../BEER/Data/BeerData.json");
        foreach (var beer in beerData)
        {
            if (beer.BeerImage != null)
            {
                byte[] imagebyte = await extractor.DownloadImageAsync(beer.BeerImage);
                BeerModel beerToAdd = new() { BeerID = Guid.NewGuid(), BeerName = beer.BeerName, BeerType = beer.BeerType, Description = beer.Description, BeerImage = imagebyte };
                beers.Add(beerToAdd);
            }
            else
            {
                BeerModel beerToAdd = new() { BeerID = Guid.NewGuid(), BeerName = beer.BeerName, BeerType = beer.BeerType, Description = beer.Description };
                modelBuilder.Entity<BeerModel>().HasData(beerToAdd);

            }
        }

        //add the lists of models
        foreach (var beerlover in beerLovers)
        {
            Console.WriteLine(beerlover);
            modelBuilder.Entity<BeerLoverModel>().HasData(beerlover);

        }
        foreach (var group in beerGroups)
        {
            Console.WriteLine(group);
            modelBuilder.Entity<BeerGroupModel>().HasData(group);
        }
        foreach (var beer in beers)
        {
            Console.WriteLine(beer);
            modelBuilder.Entity<BeerModel>().HasData(beer);
        }
    }

}

