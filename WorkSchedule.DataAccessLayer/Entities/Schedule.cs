namespace WorkSchedule.DataAccessLayer.Entities;

public class Schedule : BaseEntity<int>
{
    public DateOnly ScheduleStart { get; set; }
    public virtual WorkSchema WorkSchema { get; set; } = null!;
    public int WorkSchemaId { get; set; } = default!;
    public virtual Employee Employee { get; set; } = null!;
    public int EmployeeId { get; set; } = default!;
    public virtual WorkMonth WorkMonth { get; set; } = null!;
    public int WorkMonthId { get; set; }
}