using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record RequestRemoveListEmployeeDto
{
    [Required] public IEnumerable<RequestRemoveEmployeeDto> Employees { get; init; } = null!;
}