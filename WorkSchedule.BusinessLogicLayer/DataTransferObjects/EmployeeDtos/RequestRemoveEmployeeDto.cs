using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record RequestRemoveEmployeeDto
{
    [Required] [Range(1, int.MaxValue)] public int Id { get; set; }
}