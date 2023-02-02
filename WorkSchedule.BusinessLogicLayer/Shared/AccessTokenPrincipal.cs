namespace WorkSchedule.BusinessLogicLayer.Shared;

public record AccessTokenPrincipal
{
    public string SecretKey { get; init; } = null!;
    public string? ValidIssuer { get; init; }
    public string? ValidAudience { get; init; }
    public string? SecurityAlgorithms { get; init; }
    public int TokenLifetimeInMinutes { get; init; } = default!;
    public DateTime? NotBefore { get; init; }
}