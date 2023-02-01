using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class DatabaseContextExtension
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WorkScheduleDbContext>(opt =>
        {
            opt.UseLazyLoadingProxies().UseNpgsql(connectionString);
        });
        return services;
    }
}