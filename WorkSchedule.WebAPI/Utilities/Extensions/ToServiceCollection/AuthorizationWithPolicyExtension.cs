using System.Security.Claims;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class AuthorizationWithPolicyExtension
{
    public static IServiceCollection AddAuthorizationWithPolicy(this IServiceCollection services)
    {
        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(Roles.Admin,
                b => { b.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Roles.Admin)); });
            opt.AddPolicy(Roles.User, b =>
            {
                b.RequireAssertion(x =>
                    x.User.HasClaim(ClaimTypes.Role, Roles.User) || x.User.HasClaim(ClaimTypes.Role, Roles.Admin));
            });
        });

        return services;
    }
}