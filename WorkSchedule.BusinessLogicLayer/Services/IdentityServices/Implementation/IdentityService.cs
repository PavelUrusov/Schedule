using System.Net;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.RoleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.TokenDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.UserDtos;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;

public class IdentityService : IIdentityService
{
    private readonly IPasswordManager _passwordManager;
    private readonly IRoleManager _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IUserManager _userManager;

    public IdentityService(IUserManager userManager, IRoleManager roleManager, ITokenService tokenService,
        IPasswordManager passwordManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _passwordManager = passwordManager;
    }

    public virtual async Task<ResponseBase> LoginAsync(RequestLoginBaseUserDto requestLoginBaseUserDto)
    {
        var verifyCredentials = await VerifyUserCredentialsAsync(requestLoginBaseUserDto);
        if (verifyCredentials.IsUnsuccessful)
            return new ResponseBase(verifyCredentials.ErrorMessage, HttpStatusCode.BadRequest);

        var user = verifyCredentials.Data!;
        var userClaims = _userManager.GetUserClaims(user);
        var accessToken = _tokenService.CreateAccessToken(userClaims);
        var refreshToken = await _tokenService.CreateRefreshTokenForUserAsync(user);

        return new ResponseTokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
    }

    public virtual async Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto)
    {
        var role = new Role { Name = roleDto.Name };
        var result = await _roleManager.CreateRoleAsync(role);

        return result.IsSuccessful
            ? new ResponseBase()
            : new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);
    }

    public virtual async Task<ResponseBase> RegistrationAsync(RequestRegisterBaseUserDto requestRegisterBaseDto)
    {
        var existingRole = await _roleManager.FindByNameAsync(Roles.User);
        if (existingRole.IsUnsuccessful)
            return new ResponseBase("Basic role user - not found", HttpStatusCode.BadRequest);

        var user = new User
        {
            Roles = new List<Role> { existingRole.Data! },
            Username = requestRegisterBaseDto.Username,
            Email = requestRegisterBaseDto.Email,
            RegistrationUnixTimeSecondsUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };
        var result = await _userManager.CreateNewUserAsync(user, requestRegisterBaseDto.Password);

        return result.IsSuccessful
            ? new ResponseBase()
            : new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);
    }

    public virtual async Task<ResponseBase> RefreshToken(RequestTokenDto requestToken)
    {
        var result = _tokenService.GetAccessTokenPrincipalFromExpiredToken(requestToken.AccessToken);
        if (result.IsUnsuccessful)
            return new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);

        var principal = result.Data!;
        var userId = Convert.ToInt32(principal.Claims.Single(c => c.Type is "userId").Value);
        var foundUser = await _userManager.FindUserByIdAsync(userId);
        var user = foundUser.Data!;
        if (foundUser.IsUnsuccessful)
            return new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);

        var userRefreshToken = user.RefreshTokens.FirstOrDefault(x => x.Token == requestToken.RefreshToken);
        if (userRefreshToken is null
            || userRefreshToken.IsValid is false
            || userRefreshToken.ExpireAtUnixTimeSecUtc < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            return new ResponseBase("Invalid refresh requestToken", HttpStatusCode.BadRequest);

        var newRefreshToken = await _tokenService.OverwriteRefreshTokenAsync(userRefreshToken);
        var accessToken = _tokenService.CreateAccessToken(_userManager.GetUserClaims(user));

        return new ResponseTokenDto { AccessToken = accessToken, RefreshToken = newRefreshToken };
    }

    private async Task<Result<User?>> VerifyUserCredentialsAsync(RequestLoginBaseUserDto dto)
    {
        var findEmail = await _userManager.FindUserByEmailAsync(dto.Email);
        if (findEmail.IsUnsuccessful)
            return new Result<User?>("Incorrect password or email");

        var verifyPassword = _passwordManager.VerifyPassword(dto.Password, findEmail.Data!.Password);

        return verifyPassword.IsSuccessful
            ? new Result<User?>(findEmail.Data)
            : new Result<User?>("Incorrect password or email");
    }
}