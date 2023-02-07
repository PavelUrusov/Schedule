using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;

public record AddListEmployeeDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public IEnumerable<EmployeeDto> Dtos { get; init; } = null!;

    [Required(ErrorMessage = "The WorkObjectId property is required")]
    [Range(1, int.MaxValue)]
    public int WorkObjectId { get; init; }
}