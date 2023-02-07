namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.TokenDtos;

public record TokenResponse : ResponseBase
{
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}