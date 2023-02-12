using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.TokenDtos;

public record RequestTokenDto
{
    [Required(ErrorMessage = "The AccessToken property is required")]
    public string AccessToken { get; init; } = null!;

    [Required(ErrorMessage = "The RefreshToken property is required")]
    public string RefreshToken { get; init; } = null!;
}