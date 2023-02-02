using WorkSchedule.BusinessLogicLayer.Services.Identity.IdentityService;
using WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordEncryption;
using WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordManager;
using WorkSchedule.BusinessLogicLayer.Services.Identity.RoleManager;
using WorkSchedule.BusinessLogicLayer.Services.Identity.TokenService;
using WorkSchedule.BusinessLogicLayer.Services.Identity.UserManager;

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