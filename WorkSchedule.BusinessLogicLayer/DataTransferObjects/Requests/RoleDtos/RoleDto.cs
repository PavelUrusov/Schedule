using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.RoleDtos;

public record AddRoleDto
{
    [Required(ErrorMessage = "The role name property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Role name must contain between 3 and 30 characters")]
    public string Name { get; init; } = null!;
}