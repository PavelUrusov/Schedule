using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record RequestAddEmployeeDto : BaseEmployeeDto
{
    [Required] public RequestGetWorkObjectDto WorkObject { get; init; } = null!;
}