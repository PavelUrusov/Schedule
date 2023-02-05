using System.Net;
using System.Text.Json.Serialization;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public record ResponseBase
{
    public ResponseBase()
    {
    }

    public ResponseBase(string? errorMessage, HttpStatusCode httpStatusCode)
    {
        ErrorMessage = errorMessage;
        HttpStatusCode = httpStatusCode;
    }

    public HttpStatusCode HttpStatusCode { get; init; } = HttpStatusCode.OK;
    [JsonIgnore]
    public int StatusCode => (int)HttpStatusCode;
    public string? ErrorMessage { get; init; }
}