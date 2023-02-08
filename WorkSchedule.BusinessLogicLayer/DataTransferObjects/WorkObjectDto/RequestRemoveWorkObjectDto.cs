using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

public record RequestRemoveWorkObjectDto
{
    [Required] [Range(1, int.MaxValue)] public int WorkObjectId { get; init; }
}