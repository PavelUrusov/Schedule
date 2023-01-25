namespace WorkSchedule.DataAccessLayer.Entities;

public class Employee : BaseEntity<int>
{
    public string Firstname { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Lastname { get; set; }
    public virtual WorkObject WorkObject { get; set; } = null!;
    public int WorkObjectId { get; set; } = default!;
    public virtual IEnumerable<Schedule> Schedules { get; set; } = null!;
}