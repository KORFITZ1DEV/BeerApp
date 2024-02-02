using System.Linq.Expressions;
using DataAccessLibrary.DataAccess.Interfaces;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess;

public abstract class ModelContext<T> : IModelContext<T> where T : class
{
    protected readonly DataContext Context;

    protected ModelContext(DataContext context)
    {
        Context = context;
    }

    public abstract Task<T?> GetOneWhere(Expression<Func<T, bool>> predicate);

    public abstract Task<List<T>> GetAllWhere(Expression<Func<T, bool>> predicate);

    public abstract Task<List<T>> GetAll();

    public abstract Task Add(T model);

    public abstract Task Update(T model);

    public abstract Task Delete(T model);
}