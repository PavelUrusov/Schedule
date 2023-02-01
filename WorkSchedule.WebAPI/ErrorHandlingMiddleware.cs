using System.Net;
using Newtonsoft.Json;

namespace WorkSchedule.WebAPI;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Message = exception.Message

        }.ToString());
    }
}

public class ErrorDetails
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = null!;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}