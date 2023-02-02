using System.Net;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public record ResponseBase
{
    public ResponseBase()
    {
    }

    public ResponseBase(string? errorMessage, HttpStatusCode statusCode)
    {
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    public string? ErrorMessage { get; init; }
}

public record ResponseBase<T> : ResponseBase
{
    public T? Data { get; init; }
}