using System.Security.Claims;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;

public interface ITokenService
{
    string CreateAccessToken(IEnumerable<Claim> claims);
    RefreshToken CreateRefreshToken();
    Result<ClaimsPrincipal?> GetAccessTokenPrincipalFromExpiredToken(string token);
    Task<string> OverwriteRefreshTokenAsync(RefreshToken refreshToken);
    Task AddRefreshTokenForUser(User user, RefreshToken token);
}