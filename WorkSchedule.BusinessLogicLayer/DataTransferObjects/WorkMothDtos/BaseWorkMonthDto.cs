using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;

public record BaseWorkMonthDto : IMapWith<WorkMonth>
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;
}