using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.DataAccessLayer.Entities;

public class WorkSchema : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual DayType[] Scheme { get; set; } = null!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
    public virtual IEnumerable<Schedule> Schedules { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public int UserId { get; set; } = default!;
}