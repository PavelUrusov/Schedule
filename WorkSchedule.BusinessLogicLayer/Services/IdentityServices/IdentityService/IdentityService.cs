using System.Net;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.RoleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.TokenDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.UserDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.TokenDtos;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.PasswordManager;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.RoleManager;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.TokenService;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.UserManager;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

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

    public virtual async Task<ResponseBase> LoginAsync(LoginUserDto loginUserDto)
    {
        var verifyCredentials = await VerifyUserCredentialsAsync(loginUserDto);
        if (verifyCredentials.IsUnsuccessful)
            return new ResponseBase(verifyCredentials.ErrorMessage, HttpStatusCode.BadRequest);

        var user = verifyCredentials.Data!;
        var userClaims = _userManager.GetUserClaims(user);
        var accessToken = _tokenService.CreateAccessToken(userClaims);
        var refreshToken = await _tokenService.CreateRefreshTokenForUserAsync(user);

        return new TokenResponse{AccessToken = accessToken, RefreshToken = refreshToken};
    }

    public virtual async Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto)
    {
        var role = new Role { Name = roleDto.Name };
        var result = await _roleManager.CreateRoleAsync(role);

        return result.IsSuccessful
            ? new ResponseBase()
            : new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);
    }

    public virtual async Task<ResponseBase> RegistrationAsync(RegisterUserDto registerDto)
    {
        var existingRole = await _roleManager.FindByNameAsync(Roles.User);
        if (existingRole.IsUnsuccessful)
            return new ResponseBase("Basic role user - not found", HttpStatusCode.BadRequest);

        var user = new User
        {
            Roles = new List<Role> { existingRole.Data! },
            Username = registerDto.Username,
            Email = registerDto.Email,
            RegistrationUnixTimeSecondsUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };
        var result = await _userManager.CreateNewUserAsync(user, registerDto.Password);

        return result.IsSuccessful
            ? new ResponseBase()
            : new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);
    }

    public virtual async Task<ResponseBase> RefreshToken(TokenRequestDto token)
    {
        var result = _tokenService.GetAccessTokenPrincipalFromExpiredToken(token.AccessToken);
        if (result.IsUnsuccessful)
            return new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);

        var principal = result.Data!;
        var userId = Convert.ToInt32(principal.Claims.Single(c => c.Type is "userId").Value);
        var foundUser = await _userManager.FindUserByIdAsync(userId);
        var user = foundUser.Data!;
        if (foundUser.IsUnsuccessful)
            return new ResponseBase(result.ErrorMessage, HttpStatusCode.BadRequest);

        var userRefreshToken = user.RefreshTokens.FirstOrDefault(x => x.Token == token.RefreshToken);
        if (userRefreshToken is null
            || userRefreshToken.IsValid is false
            || userRefreshToken.ExpireAtUnixTimeSecUtc < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            return new ResponseBase("Invalid refresh token", HttpStatusCode.BadRequest);

        var newRefreshToken = await _tokenService.OverwriteRefreshTokenAsync(userRefreshToken);
        var accessToken = _tokenService.CreateAccessToken(_userManager.GetUserClaims(user));

        return new TokenResponse{AccessToken = accessToken, RefreshToken = newRefreshToken};
    }

    private async Task<Result<User?>> VerifyUserCredentialsAsync(LoginUserDto dto)
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