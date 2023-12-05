using Microsoft.EntityFrameworkCore;
using ModelLibrary;

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

        modelBuilder.Entity<BeerModel>().HasData(
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "Geuss new", BeerType = BeerType.ALE, AleSubType = AleSubType.PALE_ALE, Brewery = "Geuss Brewery" },
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "IPA london", BeerType = BeerType.ALE, AleSubType = AleSubType.INDIA_PALE_ALE, Brewery = "London Brewing Co" },
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "Grimberger double amber", BeerType = BeerType.LAGER, LagerSubType = LagerSubType.AMBER_LAGER, Brewery = "Grimberger Brewery" },
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "Anakisten bluberry", BeerType = BeerType.SPECIALTY_HYBRID, SpecialtyHybridSubType = SpecialtyHybridSubType.FRUIT_BEER, Brewery = "Anakisten Brewing" },
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "Trapist lakrids", BeerType = BeerType.STRONG_ALE, StrongAleSubType = StrongAleSubType.ABBEY_TRAPPIST_ALE, Brewery = "Trapist Brews" },
            new BeerModel { BeerID = Guid.NewGuid(), BeerName = "Carlsberg pilsner", BeerType = BeerType.LAGER, LagerSubType = LagerSubType.PILSNER, Brewery = "Carlsberg Brewery" }
        // Add other beers as needed
        );

        // modelBuilder.Entity<RatingModel>().HasData(
        //     new RatingModel { RatingID = Guid.NewGuid(), RatingScore = 4.5, Beer = new BeerModel { BeerID = Guid.NewGuid(), BeerName = "IPA TEST", BeerType = BeerType.ALE, AleSubType = AleSubType.INDIA_PALE_ALE, Brewery = "TEST Brewing Co" }, Taster = new BeerLoverModel { BeerLoverID = Guid.NewGuid(), BeerLoverName = "Test Doe", BeerLoverEmail = "test@example.com" }, RatingDate = DateTime.Now }
        // // Add other ratings as needed
        // );
    }

}
