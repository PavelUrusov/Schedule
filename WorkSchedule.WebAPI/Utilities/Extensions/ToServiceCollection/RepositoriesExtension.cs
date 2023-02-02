using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IWorkScheduleRepository<,>), typeof(WorkScheduleWorkScheduleRepository<,>));

        return services;
    }
}