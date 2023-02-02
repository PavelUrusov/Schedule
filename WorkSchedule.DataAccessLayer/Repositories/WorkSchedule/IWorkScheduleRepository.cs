using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

public interface IWorkScheduleRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    Task InsertAsync(T entity);
    Task<T?> GetByIdAsync(object id);
    IEnumerable<T> GetAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IQueryable<T> CreateQueryable();
    Task DeleteRangeAsync(IEnumerable<T> entities);
}