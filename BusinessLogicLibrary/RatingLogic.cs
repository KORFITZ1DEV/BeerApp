using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace BusinessLogic;

public class RatingLogic : IRatingLogic
{
    private IModelContext<RatingModel> _ratingc;

    public RatingLogic(IModelContext<RatingModel> ratingc)
    {
        _ratingc = ratingc;
    }

    public async Task<RatingModel?> GetOneWhere(Expression<Func<RatingModel, bool>> predicate)
    {
        return await _ratingc.GetOneWhere(predicate);
    }
    public async Task<List<RatingModel>> GetAllWhere(Expression<Func<RatingModel, bool>> predicate)
    {
        return await _ratingc.GetAllWhere(predicate);
    }
    public async Task<List<RatingModel>> GetAll()
    {
        return await _ratingc.GetAll();
    }
    public async Task<List<RatingModel>> Update(RatingModel rating)
    {
        await _ratingc.Update(rating);
        return await GetAll();
    }
    public async Task<List<RatingModel>> Add(RatingModel rating)
    {
        await _ratingc.Add(rating);
        return await GetAll();
    }
    public async Task<List<RatingModel>> Delete(RatingModel rating)
    {
        await _ratingc.Delete(rating);
        return await GetAll();
    }
}