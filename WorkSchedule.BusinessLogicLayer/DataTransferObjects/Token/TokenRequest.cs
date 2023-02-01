using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Token;

public record TokenRequest
{
    [Required(ErrorMessage = "The AccessToken property is required")]
    public string AccessToken { get; set; } = null!;

    [Required(ErrorMessage = "The RefreshToken property is required")]
    public string RefreshToken { get; set; } = null!;
}