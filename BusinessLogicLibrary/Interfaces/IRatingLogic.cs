using System.Linq.Expressions;
using ModelLibrary;

namespace BusinessLogic.Interfaces;

public interface IRatingLogic
{
    Task<RatingModel?> GetOneWhere(Expression<Func<RatingModel, bool>> predicate);
    Task<List<RatingModel>> GetAllWhere(Expression<Func<RatingModel, bool>> predicate);
    Task<List<RatingModel>> GetAll();
    Task<List<RatingModel>> Update(RatingModel rating);
    Task<List<RatingModel>> Add(RatingModel rating);
    Task<List<RatingModel>> Delete(RatingModel rating);
}