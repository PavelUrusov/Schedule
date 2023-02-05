using System.Linq.Expressions;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

public interface IWorkScheduleRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    Task InsertAsync(T entity);
    Task<T?> GetByIdAsync(object id);
    IEnumerable<T> AsEnumerable();
    Task<List<T>> ToListAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IQueryable<T> CreateQueryable();
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task InsertRangeAsync(IEnumerable<T> entities);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T?, bool>> predicate);
    Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
}