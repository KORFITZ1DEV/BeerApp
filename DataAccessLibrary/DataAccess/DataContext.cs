using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

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


    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Adding the Beerlover data from beerloverdata.json
        List<BeerLoverModel> beerLoverData = await extractor.ExtractData("../BEER/Data/BeerLoverData.json", async (BeerLoverModel beerLover) =>
        {
            if (beerLover.ProfilePic != null)
            {
                string url = BitConverter.ToString(beerLover.ProfilePic);
                beerLover.ProfilePic = await extractor.DownloadImageAsByteArray(url);
            }
        });
        foreach (var beerLover in beerLoverData)
        {
            beerLover.BeerLoverID = Guid.NewGuid();
            modelBuilder.Entity<BeerLoverModel>().HasData(beerLover);
        };

        //Adding the Beergroup data from beergroupData.json
        List<BeerGroupModel> beerGroupsData = await extractor.ExtractData("../BEER/Data/BeerLoverData.json", async (BeerGroupModel beergroup) =>
        {
            if (beergroup.GroupImage != null)
            {
                string url = BitConverter.ToString(beergroup.GroupImage);
                beergroup.GroupImage = await extractor.DownloadImageAsByteArray(url);
            }
        });
        foreach (var group in beerGroupsData)
        {
            group.BeerGroupID = Guid.NewGuid();
            modelBuilder.Entity<BeerGroupModel>().HasData(group);
        };

        //Adding the Brewery data from beerdata.json 
        List<BreweryModel> breweriesData = await extractor.ExtractData("../BEER/Data/BeerLoverData.json", async (BreweryModel brewery) => { });
        foreach (var brewery in breweriesData)
        {
            // Generate GUID dynamically
            brewery.BreweryID = Guid.NewGuid();
            // Configure with modelBuilder
            modelBuilder.Entity<BreweryModel>().HasData(brewery);
        };

        //Adding the beer data from beerdata.json 
        List<BeerModel> beerData = await extractor.ExtractData("../BEER/Data/BeerData.json", async (BeerModel beer) =>
      {
          if (beer.BeerImage != null)
          {
              string url = BitConverter.ToString(beer.BeerImage);
              beer.BeerImage = await extractor.DownloadImageAsByteArray(url);
          }
      });

        foreach (var beer in beerData)
        {
            beer.BeerID = Guid.NewGuid();
            modelBuilder.Entity<BeerModel>().HasData(beer);
        }

    }
}
