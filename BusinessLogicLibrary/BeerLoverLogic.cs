using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace BusinessLogic;

public class BeerLoverLogic : IBeerLoverLogic
{
    private IModelContext<BeerLoverModel> _beerLoverc;

    public BeerLoverLogic(IModelContext<BeerLoverModel> beerLoverc)
    {
        _beerLoverc = beerLoverc;
    }
    public async Task<BeerLoverModel?> GetOneWhere(Expression<Func<BeerLoverModel, bool>> predicate)
    {
        return await _beerLoverc.GetOneWhere(predicate);
    }
    public async Task<List<BeerLoverModel>> GetAllWhere(Expression<Func<BeerLoverModel, bool>> predicate)
    {
        return await _beerLoverc.GetAllWhere(predicate);
    }
    public async Task<List<BeerLoverModel>> GetAll()
    {
        return await _beerLoverc.GetAll();
    }
    public async Task<List<BeerLoverModel>> Update(BeerLoverModel beerLover)
    {
        await _beerLoverc.Update(beerLover);
        return await GetAll();

    }
    public async Task<List<BeerLoverModel>> Add(BeerLoverModel beerLover)
    {
        await _beerLoverc.Add(beerLover);
        return await GetAll();

    }
    public async Task<List<BeerLoverModel>> Delete(BeerLoverModel beerLover)
    {
        await _beerLoverc.Delete(beerLover);
        return await GetAll();

    }
}