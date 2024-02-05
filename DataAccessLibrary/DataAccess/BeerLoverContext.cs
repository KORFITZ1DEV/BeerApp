using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public class BeerLoverContext : ModelContext<BeerLoverModel>
{
    public BeerLoverContext(DataContext context) : base(context)
    {
    }

    public override async Task<BeerLoverModel?> GetOneWhere(Expression<Func<BeerLoverModel, bool>> predicate)
    {
        return await Context.BeerLovers.FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<BeerLoverModel>> GetAllWhere(Expression<Func<BeerLoverModel, bool>> predicate)
    {
        return await Context.BeerLovers.Where(predicate).ToListAsync();
    }

    public override async Task<List<BeerLoverModel>> GetAll()
    {
        return await Context.BeerLovers.ToListAsync();
    }

    public override async Task Add(BeerLoverModel beerLover)
    {
        Context.BeerLovers.Add(beerLover);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();

    }

    public override async Task Update(BeerLoverModel beerLover)
    {
        Context.BeerLovers.Update(beerLover);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }

    public override async Task Delete(BeerLoverModel beerLover)
    {
        Context.BeerLovers.Remove(beerLover);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }
}