using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Role;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Token;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.User;
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
    public async Task<IActionResult> RegistrationUser([FromBody] RegisterUserRequest request)
    {
        var response = await _identityService.RegistrationAsync(request);

        return StatusCode((int)response.StatusCode, response);
    }

    [Authorize(Policy = "Admin")]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
    {
        var response = await _identityService.AddRoleAsync(request);

        return StatusCode((int)response.StatusCode, response);
    }

    [AllowAnonymous]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
    {
        var response = await _identityService.LoginAsync(loginUserRequest);

        return StatusCode((int)response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequest token)
    {
        var response = await _identityService.RefreshToken(token);

        return StatusCode((int)response.StatusCode, response);
    }
}