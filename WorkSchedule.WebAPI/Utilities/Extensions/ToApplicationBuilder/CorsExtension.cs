namespace WorkSchedule.WebAPI.Utilities.Extensions.ToApplicationBuilder;

public static class CorsExtension
{
    public static IApplicationBuilder AddCustomCors(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseCors(options =>
            options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

        return applicationBuilder;
    }
}