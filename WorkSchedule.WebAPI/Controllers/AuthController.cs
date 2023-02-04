using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Role;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Token;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.User;
using WorkSchedule.BusinessLogicLayer.Services.Identity.IdentityService;

namespace WorkSchedule.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IIdentityService identityService, ILogger<AuthController> logger)
    {
        _identityService = identityService;
        _logger = logger;
    }

    [AllowAnonymous]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> RegistrationUser([FromBody] RegisterUserDto dto)
    {
        var response = await _identityService.RegistrationAsync(dto);

        return StatusCode((int)response.StatusCode, response);
    }

    [Authorize(Policy = "Admin")]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] AddRoleDto dto)
    {
        var response = await _identityService.AddRoleAsync(dto);

        return StatusCode((int)response.StatusCode, response);
    }

    [AllowAnonymous]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        var response = await _identityService.LoginAsync(loginUserDto);

        return StatusCode((int)response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto token)
    {
        var response = await _identityService.RefreshToken(token);

        return StatusCode((int)response.StatusCode, response);
    }
}