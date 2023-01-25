using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WorkSchedule.DataAccessLayer.Database;

public class WorkScheduleDbContext : DbContext
{
    public WorkScheduleDbContext(DbContextOptions<WorkScheduleDbContext> options)
        : base(options)
    {
    }

    public WorkScheduleDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}