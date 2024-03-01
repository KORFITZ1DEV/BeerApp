using System.Linq.Expressions;
using ModelLibrary;

namespace BusinessLogic.Interfaces;

public interface IBeerLogic
{
    Task<BeerModel?> GetOneWhere(Expression<Func<BeerModel, bool>> predicate);
    Task<List<BeerModel>> GetAllWhere(Expression<Func<BeerModel, bool>> predicate);
    Task<List<BeerModel>> GetAll();
    Task<List<BeerModel>> Update(BeerModel beer);
    Task<List<BeerModel>> Add(BeerModel beer);
    Task<List<BeerModel>> Delete(BeerModel beer);

}