using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

public record RequestAddScheduleDto
{
    [Required] [DataType(DataType.Date)] public string ScheduleStart { get; init; } = null!;

    [Required] [Range(1, int.MaxValue)] public int EmployeeId { get; init; }

    [Required] [Range(1, int.MaxValue)] public int WorkSchemaId { get; init; }

    [Required] [Range(1, int.MaxValue)] public int WorkMonthId { get; init; }
}