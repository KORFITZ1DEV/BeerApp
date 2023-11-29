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
        // Configure BeerLoverModel
        // modelBuilder.Entity<BeerLoverModel>()
        //     .Property(bl => bl.BeerLoverID)
        //     .ValueGeneratedOnAdd();

        // Configure BeerModel
        // modelBuilder.Entity<BeerModel>()
        //     .Property(b => b.BeerID)
        //     .ValueGeneratedOnAdd();

        // Configure BeerGroupModel
        // modelBuilder.Entity<BeerGroupModel>()
        //     .Property(bg => bg.BeerGroupID)
        //     .ValueGeneratedOnAdd();

        // Configure RatingsModel
        // modelBuilder.Entity<RatingModel>()
        //     .Property(r => r.RatingID)
        //     .ValueGeneratedOnAdd();

    }
}