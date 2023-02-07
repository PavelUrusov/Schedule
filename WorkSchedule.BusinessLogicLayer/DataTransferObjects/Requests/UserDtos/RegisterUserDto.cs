using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.UserDtos;

public record RegisterUserDto:UserDto
{
    [Required(ErrorMessage = "The Username property is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must contain between 6 and 30 characters")]
    public string Username { get; init; } = null!;
}