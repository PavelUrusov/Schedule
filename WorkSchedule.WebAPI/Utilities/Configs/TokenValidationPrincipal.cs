namespace WorkSchedule.WebAPI.Utilities.Configs;

public record TokenValidationPrincipal
{
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public string? ValidIssuer { get; set; }
    public IEnumerable<string>? ValidAudiences { get; set; }
    public string SecretKey { get; set; } = null!;
    public TimeSpan ClockSkew { get; set; }
}