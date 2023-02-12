using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;

public class TokenService : ITokenService
{
    private readonly AccessTokenPrincipal _accessTokenPrincipal;
    private readonly RefreshTokenPrincipal _refreshTokenPrincipal;
    private readonly IRefreshTokenRepository _tokenRepository;

    public TokenService(
        IOptions<AccessTokenPrincipal> accessTokenPrincipal,
        IOptions<RefreshTokenPrincipal> refreshTokenPrincipal,
        IRefreshTokenRepository tokenRepository)
    {
        _refreshTokenPrincipal = refreshTokenPrincipal.Value;
        _tokenRepository = tokenRepository;
        _accessTokenPrincipal = accessTokenPrincipal.Value;
        if (string.IsNullOrWhiteSpace(_accessTokenPrincipal.SecretKey))
            throw new ArgumentException("The secret key cannot be null, empty, or contain white spaces");
    }

    public virtual string CreateAccessToken(IEnumerable<Claim> claims)
    {
        var securityKey = CreateSymmetricKey(_accessTokenPrincipal.SecretKey);
        var credentials = new SigningCredentials(securityKey, _accessTokenPrincipal.SecurityAlgorithms);
        var header = new JwtHeader(credentials);

        var payload = new JwtPayload(
            _accessTokenPrincipal.ValidIssuer,
            _accessTokenPrincipal.ValidAudience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_accessTokenPrincipal.TokenLifetimeInMinutes),
            notBefore: _accessTokenPrincipal.NotBefore);

        var secToken = new JwtSecurityToken(header, payload);
        var token = new JwtSecurityTokenHandler().WriteToken(secToken);

        return token;
    }

    public virtual Result<ClaimsPrincipal?> GetAccessTokenPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = CreateSymmetricKey(_accessTokenPrincipal.SecretKey),
            ValidateLifetime = false
        };
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecToken ||
            jwtSecToken.Header.Alg.Equals(_accessTokenPrincipal.SecurityAlgorithms) is false)
            return new Result<ClaimsPrincipal?>("Invalid access token");

        return new Result<ClaimsPrincipal?>(principal);
    }

    public virtual async Task<string> OverwriteRefreshTokenAsync(RefreshToken refreshToken)
    {
        refreshToken.Token = GenerateRefreshToken();
        await _tokenRepository.UpdateAsync(refreshToken);

        return refreshToken.Token;
    }

    public virtual async Task AddRefreshTokenForUser(User user, RefreshToken token)
    {
        var tokens = user.RefreshTokens.ToArray();
        if (tokens.Length > _refreshTokenPrincipal.MaximumTokensUser)
        {
            var result = await DeleteInvalidTokensForUserAsync(user.Id);
            if (result.IsUnsuccessful) await DeleteOldestTokenForUserAsync(user.Id);
        }

        token.UserId = user.Id;
        await _tokenRepository.InsertAsync(token);
    }

    public virtual RefreshToken CreateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            ExpireAtUnixTimeSecUtc
                = DateTimeOffset.UtcNow.AddDays(_refreshTokenPrincipal.TokenLifetimeInDays).ToUnixTimeSeconds(),
            IsValid = true,
            Token = GenerateRefreshToken()
        };

        return refreshToken;
    }

    private string GenerateRefreshToken(int amountOfBytes = 32)
    {
        var randomNumber = new byte[amountOfBytes];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    protected async Task<Result> DeleteInvalidTokensForUserAsync(int userId)
    {
        var deleteTokens = await FindInvalidTokensFromUserAsync(userId);
        if (deleteTokens.Count < 0)
            return new Result("No invalid tokens");

        await _tokenRepository.DeleteRangeAsync(deleteTokens);

        return new Result();
    }

    protected async Task DeleteOldestTokenForUserAsync(int userId)
    {
        var oldestTokens = await FindOldestTokenFromUserAsync(userId);
        await _tokenRepository.DeleteRangeAsync(oldestTokens);
    }

    protected SymmetricSecurityKey CreateSymmetricKey(string secretKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }

    protected async Task<List<RefreshToken>> FindInvalidTokensFromUserAsync(int userId)
    {
        var invalidTokens = await _tokenRepository
            .AsQueryable()
            .Where(rf => rf.UserId == userId
                         && (rf.IsValid == false || rf.ExpireAtUnixTimeSecUtc < DateTimeOffset.UtcNow.Second))
            .ToListAsync();

        return invalidTokens;
    }

    protected async Task<List<RefreshToken>> FindOldestTokenFromUserAsync(int userId)
    {
        var oldestTokens = await _tokenRepository
            .AsQueryable()
            .Where(rf => rf.UserId == userId)
            .OrderBy(rf => rf.ExpireAtUnixTimeSecUtc)
            .Take(_refreshTokenPrincipal.MaximumTokensUser / 4)
            .ToListAsync();

        return oldestTokens;
    }
}