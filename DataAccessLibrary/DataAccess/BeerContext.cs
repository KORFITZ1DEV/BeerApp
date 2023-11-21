using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public class BeerContext : ModelContext<BeerModel>
{
    public BeerContext(DataContext context) : base(context)
    {
    }

    public override async Task<BeerModel?> GetOneWhere(Expression<Func<BeerModel, bool>> predicate)
    {
        return await Context.Beers.FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<BeerModel>> GetAllWhere(Expression<Func<BeerModel, bool>> predicate)
    {
        return await Context.Beers.Where(predicate).ToListAsync();
    }

    public override async Task<List<BeerModel>> GetAll()
    {
        return await Context.Beers.AsNoTracking().ToListAsync();
    }

    public override async Task Add(BeerModel beer)
    {
        Context.Beers.Add(beer);
        await Context.SaveChangesAsync();
    }

    public override async Task Update(BeerModel beer)
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

    public override async Task Delete(BeerModel beer)
    {
        Context.Beers.Remove(beer);
        await Context.SaveChangesAsync();
    }
}