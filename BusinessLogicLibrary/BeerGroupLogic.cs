using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace BusinessLogic;

public class BeerGroupLogic : IBeerGroupLogic
{
    private IModelContext<BeerGroupModel> _groupc;

    public BeerGroupLogic(IModelContext<BeerGroupModel> groupc)
    {
        _groupc = groupc;
    }
    public async Task<BeerGroupModel?> GetOneWhere(Expression<Func<BeerGroupModel, bool>> predicate)
    {
        return await _groupc.GetOneWhere(predicate);

    }
    public async Task<List<BeerGroupModel>> GetAllWhere(Expression<Func<BeerGroupModel, bool>> predicate)
    {
        return await _groupc.GetAllWhere(predicate);
    }
    public async Task<List<BeerGroupModel>> GetAll()
    {
        return await _groupc.GetAll();
    }
    public async Task<List<BeerGroupModel>> Update(BeerGroupModel group)
    {
        await _groupc.Update(group);
        return await GetAll();

    }
    public async Task<List<BeerGroupModel>> Add(BeerGroupModel group)
    {
        await _groupc.Add(group);
        return await GetAll();
    }
    public async Task<List<BeerGroupModel>> Delete(BeerGroupModel group)
    {
        await _groupc.Delete(group);
        return await GetAll();

    }
}