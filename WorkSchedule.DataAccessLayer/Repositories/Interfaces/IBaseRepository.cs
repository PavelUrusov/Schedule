using System.Linq.Expressions;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.Interfaces;

public interface IBaseRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    Task InsertAsync(T entity);
    Task<T?> FindByIdAsync(object id);
    Task<List<T>> ToListAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> BuildQueryAsync(Func<IQueryable<T>, IQueryable<T>> queryBuilder);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task InsertRangeAsync(IEnumerable<T> entities);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T?, bool>> predicate);
    Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
    Task<T?> SingleOrDefaultAsync(Expression<Func<T?, bool>> predicate);
    Task<T> SingleAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> AsQueryable();
}