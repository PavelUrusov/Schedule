namespace WorkSchedule.DataAccessLayer.Entities;

public class WorkMonth : BaseEntity<int>
{
    public string Date { get; set; } = null!;
    public virtual IEnumerable<Schedule> Schedules { get; set; } = null!;
    public virtual WorkObject WorkObject { get; set; } = null!;
    public int WorkObjectId { get; set; }
}