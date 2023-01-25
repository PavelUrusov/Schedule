using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories;

public interface IRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    Task InsertAsync(T entity);
    Task<T?> GetByIdAsync(TKey id);
    IEnumerable<T> GetAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IQueryable<T> CreateQueryable();
}