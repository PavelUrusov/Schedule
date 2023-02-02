namespace WorkSchedule.BusinessLogicLayer.Shared;

public record RefreshTokenPrincipal
{
    public int TokenLifetimeInDays { get; init; }
    public int MaximumTokensUser { get; init; }
}