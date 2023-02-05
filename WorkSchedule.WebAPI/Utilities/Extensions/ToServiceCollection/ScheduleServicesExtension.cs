using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class ScheduleServicesExtension
{
    public static IServiceCollection AddScheduleServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IWorkObjectService), typeof(WorkObjectService));
        return services;
    }
}