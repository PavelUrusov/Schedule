using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.User;

public record LoginUserDto
{
    [Required(ErrorMessage = "The Email property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Incorrect password or email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "The Password property is required")]
    [StringLength(36, MinimumLength = 8, ErrorMessage = "Incorrect password or email")]
    public string Password { get; set; } = null!;
}