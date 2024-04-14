using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace BusinessLogic;

public class BeerLogic : IBeerLogic
{
    private IModelContext<BeerModel> _beerc;

    public BeerLogic(IModelContext<BeerModel> beerc)
    {
        _beerc = beerc;
    }


    public async Task<BeerModel?> GetOneWhere(Expression<Func<BeerModel, bool>> predicate)
    {
        return await _beerc.GetOneWhere(predicate);
    }
    public async Task<List<BeerModel>> GetAllWhere(Expression<Func<BeerModel, bool>> predicate)
    {
        return await _beerc.GetAllWhere(predicate);
    }
    public async Task<List<BeerModel>> GetAll()
    {
        return await _beerc.GetAll();
    }
    public async Task<List<BeerModel>> Update(BeerModel beer)
    {
        await _beerc.Update(beer);
        return await GetAll();

    }
    public async Task<List<BeerModel>> Add(BeerModel beer)
    {
        await _beerc.Add(beer);
        return await GetAll();

    }
    public async Task<List<BeerModel>> Delete(BeerModel beer)
    {
        await _beerc.Delete(beer);
        return await GetAll();

    }

}