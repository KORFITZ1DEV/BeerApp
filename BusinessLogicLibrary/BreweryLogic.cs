using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace BusinessLogic;

public class BreweryLogic : IBreweryLogic
{
    private IModelContext<BreweryModel> _breweryc;

    public BreweryLogic(IModelContext<BreweryModel> breweryc)
    {
        _breweryc = breweryc;
    }
    public async Task<BreweryModel?> GetOneWhere(Expression<Func<BreweryModel, bool>> predicate)
    {
        return await _breweryc.GetOneWhere(predicate);

    }
    public async Task<List<BreweryModel>> GetAllWhere(Expression<Func<BreweryModel, bool>> predicate)
    {
        return await _breweryc.GetAllWhere(predicate);
    }
    public async Task<List<BreweryModel>> GetAll()
    {
        return await _breweryc.GetAll();
    }
    public async Task<List<BreweryModel>> Update(BreweryModel brewery)
    {
        await _breweryc.Update(brewery);
        return await GetAll();

    }
    public async Task<List<BreweryModel>> Add(BreweryModel brewery)
    {
        await _breweryc.Add(brewery);
        return await GetAll();
    }
    public async Task<List<BreweryModel>> Delete(BreweryModel group)
    {
        await _breweryc.Delete(group);
        return await GetAll();

    }
}