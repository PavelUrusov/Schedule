using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public async Task<IActionResult> RegistrationUser([FromBody] RegisterUserDto dto)
    {
        var response = await _identityService.RegistrationAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    [Authorize(Policy = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    [HttpGet]
    [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Test_Auth()
    {
        return StatusCode(200, "Hello Authorize User");
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequest token)
    {
        var response = await _identityService.RefreshAccessToken(token);
        return StatusCode((int)response.StatusCode, response);
    }
}