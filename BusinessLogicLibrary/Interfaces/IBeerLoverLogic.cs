using System.Linq.Expressions;
using ModelLibrary;

namespace BusinessLogic.Interfaces;

public interface IBeerLoverLogic
{
    Task<BeerLoverModel?> GetOneWhere(Expression<Func<BeerLoverModel, bool>> predicate);
    Task<List<BeerLoverModel>> GetAllWhere(Expression<Func<BeerLoverModel, bool>> predicate);
    Task<List<BeerLoverModel>> GetAll();
    Task<List<BeerLoverModel>> Update(BeerLoverModel beerLover);
    Task<List<BeerLoverModel>> Add(BeerLoverModel beerLover);
    Task<List<BeerLoverModel>> Delete(BeerLoverModel beerLover);

}