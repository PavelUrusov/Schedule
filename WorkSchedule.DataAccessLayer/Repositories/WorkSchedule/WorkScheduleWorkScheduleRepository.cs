using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

public class WorkScheduleWorkScheduleRepository<T, TKey> :
    IWorkScheduleRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    private readonly WorkScheduleDbContext _context;
    private readonly DbSet<T> _dbSet;

    public WorkScheduleWorkScheduleRepository(WorkScheduleDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IEnumerable<T> AsEnumerable()
    {
        return _dbSet.AsEnumerable();
    }

    public async Task<List<T>> ToListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public IQueryable<T> CreateQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task InsertRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T?, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstAsync(predicate);
    }

    public async Task<T?> SingleOrDefaultAsync(Expression<Func<T?, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }
    public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.SingleAsync(predicate);
    }
}