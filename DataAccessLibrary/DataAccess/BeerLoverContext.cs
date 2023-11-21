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

    }

    public override async Task Update(BeerLoverModel beerLover)
    {
        //     BeerModel? match = await GetOneWhere(c => c.EmailAddress.Equals(customer.EmailAddress));
        //     match!.FirstName = customer.FirstName;
        //     match.LastName = customer.LastName;
        //     match.EmailAddress = customer.EmailAddress;
        //     match.PhoneNumber = customer.PhoneNumber;
        //     match.IsFlagged = customer.IsFlagged;
        //     await Context.SaveChangesAsync();
        await Task.CompletedTask; //defualt before implementation
    }

    public override async Task Delete(BeerLoverModel beerLover)
    {
        Context.BeerLovers.Remove(beerLover);
        await Context.SaveChangesAsync();
    }
}