using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;

public record RequestAddWorkMonthDto
{
    [Required] [DataType(DataType.Date)] public string Date { get; set; } = null!;

    [Required] [Range(1, int.MaxValue)] public int WorkObjectId { get; set; }
}