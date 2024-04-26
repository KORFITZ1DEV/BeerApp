using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public class BeerGroupContext : ModelContext<BeerGroupModel>
{
    public BeerGroupContext(DataContext context) : base(context)
    {
    }

    public override async Task<BeerGroupModel?> GetOneWhere(Expression<Func<BeerGroupModel, bool>> predicate)
    {
        return await Context.BeerGroups.FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<BeerGroupModel>> GetAllWhere(Expression<Func<BeerGroupModel, bool>> predicate)
    {
        return await Context.BeerGroups.Where(predicate).ToListAsync();
    }

    public override async Task<List<BeerGroupModel>> GetAll()
    {
        return await Context.BeerGroups.AsNoTracking().ToListAsync();
    }

    public override async Task Add(BeerGroupModel group)
    {
        Context.BeerGroups.Add(group);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();

    }

    public override async Task Update(BeerGroupModel group)
    {
        Context.BeerGroups.Update(group);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }

    public override async Task Delete(BeerGroupModel group)
    {
        Context.BeerGroups.Remove(group);
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
    }
}