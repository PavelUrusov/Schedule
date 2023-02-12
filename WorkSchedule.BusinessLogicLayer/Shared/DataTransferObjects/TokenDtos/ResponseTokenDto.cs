namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.TokenDtos;

public record ResponseTokenDto : ResponseBase
{
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
}