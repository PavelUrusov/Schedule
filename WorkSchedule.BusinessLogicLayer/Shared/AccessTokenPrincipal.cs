namespace WorkSchedule.BusinessLogicLayer.Shared;

public record AccessTokenPrincipal
{
    public string SecretKey { get; set; } = null!;
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public string? SecurityAlgorithms { get; set; }
    public int TokenLifetimeInMinutes { get; set; } = default!;
    public DateTime? NotBefore { get; set; }
}