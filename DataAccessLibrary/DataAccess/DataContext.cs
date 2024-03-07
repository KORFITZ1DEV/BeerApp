using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using Newtonsoft.Json;

namespace DataAccessLibrary.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<BeerModel> Beers => Set<BeerModel>();
    public DbSet<BeerLoverModel> BeerLovers => Set<BeerLoverModel>();
    public DbSet<BeerGroupModel> BeerGroups => Set<BeerGroupModel>();
    public DbSet<RatingModel> Ratings => Set<RatingModel>();
    public DbSet<BreweryModel> Breweries => Set<BreweryModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BeerLoverModel>().HasData(
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "John Doe", BeerLoverEmail = "john@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Pop Doe", BeerLoverEmail = "Pop@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Joson Doe", BeerLoverEmail = "Joson@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Jason Doe", BeerLoverEmail = "Jason@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Casper Doe", BeerLoverEmail = "Casper@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Peter Doe", BeerLoverEmail = "Peter@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Dask Doe", BeerLoverEmail = "Dask@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Lope Doe", BeerLoverEmail = "Lope@example.com" },
            new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Gope Doe", BeerLoverEmail = "Gope@example.com" }
        // Add other beer lovers as needed
        );
        modelBuilder.Entity<BeerGroupModel>().HasData(
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "Craft Beer Enthusiasts" },
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "Ale Beer Enthusiasts" },
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "Stout Beer Enthusiasts" },
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "Test Beer Enthusiasts" },
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "New Beer Enthusiasts" },
            new BeerGroupModel { BeerGroupID = Guid.NewGuid(), GroupName = "IPA Beer Enthusiasts" }
        // Add other beer groups as needed
        );
        modelBuilder.Entity<BreweryModel>().HasData(
           new BreweryModel { BreweryID = Guid.NewGuid(), BreweryName = "Carlsberg", Country = "Denmark" },
           new BreweryModel { BreweryID = Guid.NewGuid(), BreweryName = "Munich Brewery", Country = "Germany" },
           new BreweryModel { BreweryID = Guid.NewGuid(), BreweryName = "Delerium", Country = "Belgium" }
       // Add other Breweries as needed
       );

        //Adding the beer data from beerdata.json 

        string jsonFilePath = "../BEER/Data/Beerdata.json"; // File path for beerdata
        string jsonData = File.ReadAllText(jsonFilePath);

        //load in the json data file
        List<BeerModel> beers = JsonConvert.DeserializeObject<List<BeerModel>>(jsonData);

        foreach (var beer in beers)
        {
            // Generate GUID dynamically
            beer.BeerID = Guid.NewGuid();

            // Configure with modelBuilder
            modelBuilder.Entity<BeerModel>().HasData(beer);
        }

    }

}
