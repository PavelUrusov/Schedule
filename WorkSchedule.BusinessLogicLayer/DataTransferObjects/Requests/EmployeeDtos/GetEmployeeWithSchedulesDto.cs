using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;

public record GetEmployeeWithSchedulesDto : WorkObjectIdDto
{
    [Required][DataType(DataType.Date)] public string Date { get; set; } = null!;
}