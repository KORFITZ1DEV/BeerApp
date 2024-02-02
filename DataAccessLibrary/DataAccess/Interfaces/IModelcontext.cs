using System.Linq.Expressions;
using ModelLibrary;

namespace DataAccessLibrary.DataAccess.Interfaces;

public interface IModelContext<T> where T : class
{
    Task<T?> GetOneWhere(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllWhere(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAll();
    Task Add(T model);
    Task Update(T model);
    Task Delete(T model);
}