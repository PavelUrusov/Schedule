using WorkSchedule.BusinessLogicLayer.Shared.Mappings;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class AutomapperExtension
{
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
        });
        return services;
    }
}