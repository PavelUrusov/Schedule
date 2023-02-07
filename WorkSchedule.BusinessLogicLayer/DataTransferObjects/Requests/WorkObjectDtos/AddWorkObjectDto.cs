using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;

public record AddWorkObjectDto
{
    [Required]
    [StringLength(255, ErrorMessage = "The Work object name must contain between 3 and 255 characters",
        MinimumLength = 3)]
    public string Name { get; init; } = null!;
}