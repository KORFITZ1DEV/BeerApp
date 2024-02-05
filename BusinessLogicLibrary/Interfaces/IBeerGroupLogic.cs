using System.Linq.Expressions;
using ModelLibrary;

namespace BusinessLogic.Interfaces;

public interface IBeerGroupLogic
{
    Task<BeerGroupModel?> GetOneWhere(Expression<Func<BeerGroupModel, bool>> predicate);
    Task<List<BeerGroupModel>> GetAllWhere(Expression<Func<BeerGroupModel, bool>> predicate);
    Task<List<BeerGroupModel>> GetAll();
    Task<List<BeerGroupModel>> Update(BeerGroupModel group);
    Task<List<BeerGroupModel>> Add(BeerGroupModel group);
    Task<List<BeerGroupModel>> Delete(BeerGroupModel group);

}