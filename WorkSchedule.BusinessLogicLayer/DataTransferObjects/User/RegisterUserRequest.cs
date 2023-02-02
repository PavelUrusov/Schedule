using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.User;

public record RegisterUserRequest
{
    [Required(ErrorMessage = "The Email property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Email must contain between 6 and 30 characters")]
    public string Email { get; init; } = null!;

    [Required(ErrorMessage = "The Password property is required")]
    [StringLength(36, MinimumLength = 8,
        ErrorMessage = "Password must contain at least 8 and no more than 36 characters")]
    public string Password { get; init; } = null!;

    [Required(ErrorMessage = "The Username property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must contain between 6 and 30 characters")]
    public string Username { get; init; } = null!;
}