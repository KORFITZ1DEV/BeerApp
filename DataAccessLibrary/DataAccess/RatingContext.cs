using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public class RatingContext : ModelContext<RatingModel>
{
    public RatingContext(DataContext context) : base(context)
    {
    }

    public override async Task<RatingModel?> GetOneWhere(Expression<Func<RatingModel, bool>> predicate)
    {
        return await Context.Ratings.FirstOrDefaultAsync(predicate);
    }

    public override async Task<List<RatingModel>> GetAllWhere(Expression<Func<RatingModel, bool>> predicate)
    {
        return await Context.Ratings.Where(predicate).ToListAsync();
    }

    public override async Task<List<RatingModel>> GetAll()
    {
        return await Context.Ratings.ToListAsync();
    }

    public override async Task Add(RatingModel rating)
    {
        Context.Ratings.Add(rating);
        await Context.SaveChangesAsync();

    }

    public override async Task Update(RatingModel rating)
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

    public override async Task Delete(RatingModel rating)
    {
        Context.Ratings.Remove(rating);
        await Context.SaveChangesAsync();

    }
}