using System.Net;
using System.Text.Json.Serialization;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;

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

    [JsonIgnore] public int StatusCode => (int)HttpStatusCode;

    [JsonIgnore] public bool IsSuccessful => StatusCode > 199 && StatusCode < 400;

    [JsonIgnore] public bool IsUnsuccessful => !IsSuccessful;

    public string? ErrorMessage { get; init; }
}