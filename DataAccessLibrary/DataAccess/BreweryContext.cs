using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public class BreweryContext : ModelContext<BreweryModel>
{
    public BreweryContext(DataContext context) : base(context)
    {
    }

    public override async Task<BreweryModel?> GetOneWhere(Expression<Func<BreweryModel, bool>> predicate)
    {
        return await Context.Breweries.FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<BreweryModel>> GetAllWhere(Expression<Func<BreweryModel, bool>> predicate)
    {
        return await Context.Breweries.Where(predicate).ToListAsync();
    }

    public override async Task<List<BreweryModel>> GetAll()
    {
        return await Context.Breweries.AsNoTracking().ToListAsync();
    }

    public override async Task Add(BreweryModel brewery)
    {
        Context.Breweries.Add(brewery);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }

    public override async Task Update(BreweryModel brewery)
    {
        Context.Breweries.Update(brewery);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();

    }

    public override async Task Delete(BreweryModel brewery)
    {
        Context.Breweries.Remove(brewery);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }
}