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

    public IEnumerable<T> GetAsync()
    {
        return _dbSet.AsEnumerable();
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
}