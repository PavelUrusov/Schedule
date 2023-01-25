namespace WorkSchedule.DataAccessLayer.Entities;

public class User : BaseEntity<int>
{
    public string Email { get; set; } = null!;
    public string? Password { get; set; }
    public string Username { get; set; } = null!;
    public string NormalizedUsername { get; set; } = null!;
    public string NormalizedEmail { get; set; } = null!;
    public TimeSpan RegistrationDate { get; set; } = default!;
    public virtual IEnumerable<WorkObject> WorkObjects { get; set; } = null!;
    public virtual IEnumerable<WorkSchema> WorkSchemas { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
    public virtual int RoleId { get; set; } = default!;
}