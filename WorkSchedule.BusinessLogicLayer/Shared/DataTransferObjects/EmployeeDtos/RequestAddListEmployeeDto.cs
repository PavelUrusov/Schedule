using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record RequestAddListEmployeeDto
{
    [Required] public IEnumerable<BaseEmployeeDto> Employees { get; init; } = null!;
    [Required] public RequestGetWorkObjectDto WorkObject { get; init; } = null!;
}