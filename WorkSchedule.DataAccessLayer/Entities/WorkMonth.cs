using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.DataAccessLayer.Entities;

public class WorkMonth : BaseEntity<int>
{
    public int Year { get; set; }
    public Month Month { get; set; }
    public virtual IEnumerable<Schedule> Schedules { get; set; } = null!;
    public virtual WorkObject WorkObject { get; set; } = null!;
    public int WorkObjectId { get; set; }
}