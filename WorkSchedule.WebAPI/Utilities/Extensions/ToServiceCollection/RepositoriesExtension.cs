using WorkSchedule.DataAccessLayer.Repositories.Implementation;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
        services.AddScoped(typeof(IRefreshTokenRepository), typeof(RefreshTokenRepository));
        services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
        services.AddScoped(typeof(IScheduleRepository), typeof(ScheduleRepository));
        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        services.AddScoped(typeof(IWorkMonthRepository), typeof(WorkMonthRepository));
        services.AddScoped(typeof(IWorkObjectRepository), typeof(WorkObjectRepository));
        services.AddScoped(typeof(IWorkSchemaRepository), typeof(WorkSchemaRepository));

        return services;
    }
}