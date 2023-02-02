using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.WebAPI.Utilities.Configs;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class ConfigureSettingsExtension
{
    public static IServiceCollection AddConfigureSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<TokenValidationPrincipal>(configuration.GetSection("TokenValidationPrincipal"));
        services.Configure<AccessTokenPrincipal>(configuration.GetSection("AccessTokenPrincipal"));
        services.Configure<RefreshTokenPrincipal>(configuration.GetSection("RefreshTokenPrincipal"));

        return services;
    }
}