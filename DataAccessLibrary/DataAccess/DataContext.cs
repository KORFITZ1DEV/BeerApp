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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Adding the Beerlover data from beerloverdata.json
        List<BeerLoverModel> beerLoverData = extractor.extractData<BeerLoverModel>("../BEER/Data/BeerLoverData.json");
        foreach (var beerLover in beerLoverData)
        {
            beerLover.BeerLoverID = Guid.NewGuid();
            modelBuilder.Entity<BeerLoverModel>().HasData(beerLover);
        };

        //Adding the Beergroup data from beergroupData.json
        List<BeerGroupModel> beerGroupsData = extractor.extractData<BeerGroupModel>("../BEER/Data/BeerGroupData.json");
        foreach (var group in beerGroupsData)
        {
            group.BeerGroupID = Guid.NewGuid();
            modelBuilder.Entity<BeerGroupModel>().HasData(group);
        };

        //Adding the Brewery data from beerdata.json 
        List<BreweryModel> breweriesData = extractor.extractData<BreweryModel>("../BEER/Data/Brewerydata.json");
        foreach (var brewery in breweriesData)
        {
            // Generate GUID dynamically
            brewery.BreweryID = Guid.NewGuid();
            // Configure with modelBuilder
            modelBuilder.Entity<BreweryModel>().HasData(brewery);
        };

        //Adding the beer data from beerdata.json 
        List<BeerModel> beerData = extractor.extractData<BeerModel>("../BEER/Data/BeerData.json");
        foreach (var beer in beerData)
        {
            // Generate GUID dynamically
            beer.BeerID = Guid.NewGuid();
            // Configure with modelBuilder
            modelBuilder.Entity<BeerModel>().HasData(beer);
        }
    }
}
