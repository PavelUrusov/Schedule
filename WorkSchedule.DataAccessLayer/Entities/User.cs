namespace WorkSchedule.DataAccessLayer.Entities;

public class User : BaseEntity<int>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string NormalizedEmail { get; set; } = null!;
    public long RegistrationUnixTimeSecondsUtc { get; set; } = default!;
    public virtual IEnumerable<RefreshToken> RefreshTokens { get; set; } = null!;
    public virtual IEnumerable<WorkObject> WorkObjects { get; set; } = null!;
    public virtual IEnumerable<WorkSchema> WorkSchemas { get; set; } = null!;
    public virtual IEnumerable<Role> Roles { get; set; } = null!;
}