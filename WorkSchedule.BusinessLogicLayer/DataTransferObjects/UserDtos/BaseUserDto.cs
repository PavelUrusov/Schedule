using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.UserDtos;

public record BaseUserDto
{
    [Required(ErrorMessage = "The Email property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Incorrect password or email")]
    public string Email { get; init; } = null!;

    [Required(ErrorMessage = "The Password property is required")]
    [StringLength(36, MinimumLength = 8, ErrorMessage = "Incorrect password or email")]
    public string Password { get; init; } = null!;
}