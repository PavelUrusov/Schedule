using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record RequestRemoveListEmployeeDto
{
    [Required] public IEnumerable<RequestRemoveEmployeeDto> Employees { get; init; } = null!;
}