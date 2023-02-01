using System.Security.Claims;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.TokenService;

public interface ITokenService
{
    string CreateAccessToken(IEnumerable<Claim> claims);
    Task<string> CreateRefreshTokenForUserAsync(User user);
    Result<ClaimsPrincipal?> GetAccessTokenPrincipalFromExpiredToken(string token);
    Task<string> OverwriteRefreshTokenAsync(RefreshToken refreshToken);
}