namespace WorkSchedule.BusinessLogicLayer.Shared;

public record RefreshTokenPrincipal
{
    public int TokenLifetimeInDays { get; set; }
    public int MaximumTokensUser { get; set; }
}