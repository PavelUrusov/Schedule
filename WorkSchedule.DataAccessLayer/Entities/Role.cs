namespace WorkSchedule.DataAccessLayer.Entities;

public class Role:BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string NormalizedName { get; set; } = null!;
    public virtual IEnumerable<User> Users { get; set; } = null!;
}