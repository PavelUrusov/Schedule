using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WorkSchedule.WebAPI.Utilities.Configs;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToServiceCollection;

public static class BearerAuthenticationExtension
{
    public static IServiceCollection AddBearerAuthenticationExtension(this IServiceCollection services,
        TokenValidationPrincipal principal)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = principal.ValidateIssuer,
                        ValidateAudience = principal.ValidateAudience,
                        ValidateLifetime = principal.ValidateLifetime,
                        ValidateIssuerSigningKey = principal.ValidateIssuerSigningKey,
                        ValidIssuer = principal.ValidIssuer,
                        ValidAudiences = principal.ValidAudiences,
                        ClockSkew = principal.ClockSkew,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(principal.SecretKey))
                    };
                });

        return services;
    }
}