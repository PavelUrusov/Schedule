using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos
{
    public record EmployeeIdDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}