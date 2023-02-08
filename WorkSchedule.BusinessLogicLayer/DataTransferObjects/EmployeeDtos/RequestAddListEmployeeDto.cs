using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record RequestAddListEmployeeDto
{
    [Required] public IEnumerable<BaseEmployeeDto> Employees { get; init; } = null!;
    [Required] public RequestGetWorkObjectDto WorkObject { get; init; } = null!;
}