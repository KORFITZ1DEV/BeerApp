using System.Linq.Expressions;
using ModelLibrary;

namespace BusinessLogic.Interfaces;

public interface IBreweryLogic
{
    Task<BreweryModel?> GetOneWhere(Expression<Func<BreweryModel, bool>> predicate);
    Task<List<BreweryModel>> GetAllWhere(Expression<Func<BreweryModel, bool>> predicate);
    Task<List<BreweryModel>> GetAll();
    Task<List<BreweryModel>> Update(BreweryModel brewery);
    Task<List<BreweryModel>> Add(BreweryModel brewery);
    Task<List<BreweryModel>> Delete(BreweryModel brewery);

}