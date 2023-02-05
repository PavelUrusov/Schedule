using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Employee;

public record AddEmployeeDto : EmployeeDto
{
    [Required(ErrorMessage = "The WorkObjectId property is required")]
    [Range(1, int.MaxValue)]
    public int WorkObjectId { get; init; }
}