using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public class ScheduleDto
{
    public int Id { get; set; }
    public DayType[]? Scheme { get; set; }
}