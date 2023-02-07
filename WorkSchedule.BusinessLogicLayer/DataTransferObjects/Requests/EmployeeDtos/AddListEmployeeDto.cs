using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;

public record AddListEmployeeDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(1000)]
    public IEnumerable<EmployeeDto> Employees { get; init; } = null!;

    public WorkObjectIdDto WorkObjectIdDto { get; set; } = null!;
}