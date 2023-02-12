using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.RoleDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.TokenDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.UserDtos;

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
    public async Task<IActionResult> RegistrationUser([FromBody] RequestRegisterBaseUserDto dto)
    {
        var response = await _identityService.RegistrationAsync(dto);

        return StatusCode(response.StatusCode, response);
    }

    [Authorize(Policy = "Admin")]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] AddRoleDto dto)
    {
        var response = await _identityService.AddRoleAsync(dto);

        return StatusCode(response.StatusCode, response);
    }

    [AllowAnonymous]
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] RequestLoginBaseUserDto requestLoginBaseUserDto)
    {
        var response = await _identityService.LoginAsync(requestLoginBaseUserDto);

        return StatusCode(response.StatusCode, response);
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] RequestTokenDto requestToken)
    {
        var response = await _identityService.RefreshToken(requestToken);

        return StatusCode(response.StatusCode, response);
    }
}