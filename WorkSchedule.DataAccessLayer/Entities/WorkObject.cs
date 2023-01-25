namespace WorkSchedule.DataAccessLayer.Entities;

public class WorkObject : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public int UserId { get; set; } = default!;
    public virtual IEnumerable<Employee> Employees { get; set; } = null!;
}