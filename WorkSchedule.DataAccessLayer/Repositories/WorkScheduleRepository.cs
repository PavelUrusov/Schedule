using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories;

public class WorkScheduleRepository<T, TKey> :
    IRepository<T, TKey>
    where T : BaseEntity<TKey>, new()
    where TKey : struct
{
    private readonly WorkScheduleDbContext _context;
    private readonly DbSet<T> _dbSet;

    public WorkScheduleRepository(WorkScheduleDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(TKey id)
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
}