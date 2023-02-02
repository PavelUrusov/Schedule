namespace WorkSchedule.WebAPI.Utilities.Extensions.ToApplicationBuilder;

public static class ErrorHandlingExtension
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ErrorHandlingMiddleware>();

        return applicationBuilder;
    }
}