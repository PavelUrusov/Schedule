using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record RequestRemoveEmployeeDto
{
    [Required][Range(1, int.MaxValue)] public int Id { get; set; }
}