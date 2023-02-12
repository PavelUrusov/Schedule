using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPasswordEncryptionService), typeof(PasswordEncryptionService));
        services.AddScoped(typeof(IRoleManager), typeof(RoleManager));
        services.AddScoped(typeof(IUserManager), typeof(UserManager));
        services.AddScoped(typeof(IIdentityService), typeof(IdentityService));
        services.AddScoped(typeof(ITokenService), typeof(TokenService));
        services.AddScoped(typeof(IPasswordManager), typeof(PasswordManager));

        return services;
    }
}