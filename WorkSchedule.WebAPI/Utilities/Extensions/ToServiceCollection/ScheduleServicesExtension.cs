using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.EmployeeManager;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkSchemaService;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class ScheduleServicesExtension
{
    public static IServiceCollection AddScheduleServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IWorkObjectService), typeof(WorkObjectService));
        services.AddScoped(typeof(IWorkSchemaService), typeof(WorkSchemaService));
        services.AddScoped(typeof(IEmployeeManager), typeof(EmployeeManager));
        return services;
    }
}