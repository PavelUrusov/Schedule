using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;

public record RequestAddWorkMonthDto
{
    [Required] public RequestGetWorkObjectDto WorkObject { get; init; } = null!;

    [Required] [DataType(DataType.Date)] public string Date { get; init; } = null!;
}