using Hotels.Models;
using Hotels.Models.Models.QueryResponse;
using Hotels.Models.Models.Response;

namespace Hotels.DataAccess.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(int? id);
    Task<TResult> GetAsync<TResult>(int? id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<TResult>> GetAllAsync<TResult>();
    Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
    Task<T> AddAsync(T entity);
    Task<TResult> AddAsync<TSource, TResult>(TSource source);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBase;
    Task<bool> Exists(int id);
}
