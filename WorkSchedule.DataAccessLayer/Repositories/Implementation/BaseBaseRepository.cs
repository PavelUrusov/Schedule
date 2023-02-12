using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public abstract class BaseBaseRepository<T, TKey> :
    IBaseRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    protected readonly WorkScheduleDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected BaseBaseRepository(WorkScheduleDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<T?> FindByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<List<T>> ToListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<List<T>> BuildQueryAsync(Func<IQueryable<T>, IQueryable<T>> queryBuilder)
    {
        var query = _dbSet.AsQueryable();
        query = queryBuilder(query);

        return await query.ToListAsync();
    }

    public virtual IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task InsertRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T?, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstAsync(predicate);
    }

    public virtual async Task<T?> SingleOrDefaultAsync(Expression<Func<T?, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }

    public virtual async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.SingleAsync(predicate);
    }
}