using System.ComponentModel.DataAnnotations;
using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;

public record RequestAddWorkSchemaDto
{
    [Required]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "The Name must contain between 6 and 255 characters")]
    public string Name { get; init; } = null!;

    [MinLength(2)]
    [MaxLength(31)]
    [Required]
    public DayType[] Scheme { get; init; } = null!;

    [DataType(DataType.Time)] [Required] public string StartTime { get; init; } = null!;

    [DataType(DataType.Time)] [Required] public string EndTime { get; init; } = null!;
}