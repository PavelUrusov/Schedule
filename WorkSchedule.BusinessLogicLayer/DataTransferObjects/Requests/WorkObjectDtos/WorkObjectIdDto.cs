using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;

public record WorkObjectIdDto
{
    [Required] [Range(1, int.MaxValue)] public int Id { get; init; }
}