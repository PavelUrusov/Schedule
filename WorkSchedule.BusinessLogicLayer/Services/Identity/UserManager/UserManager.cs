using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordEncryption;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.UserManager;

public class UserManager : IUserManager
{
    private readonly IPasswordEncryptionService _passwordEncryptionService;
    private readonly IWorkScheduleRepository<RefreshToken, int> _tokenRepository;
    private readonly IWorkScheduleRepository<User, int> _userRepository;

    public UserManager(IWorkScheduleRepository<User, int> userRepository,
        IPasswordEncryptionService passwordEncryptionService,
        IWorkScheduleRepository<RefreshToken, int> tokenRepository)
    {
        _passwordEncryptionService = passwordEncryptionService;
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
    }

    public virtual async Task<Result<User?>> FindUserByEmailAsync(string email)
    {
        var normalizedEmail = email.Normalize();
        var user = await _userRepository.CreateQueryable()
            .SingleOrDefaultAsync(x => x.NormalizedEmail == normalizedEmail);
        return user is not null
            ? new Result<User?>(user)
            : new Result<User?>("User not found");
    }

    public virtual async Task<Result> UpdateUserAsync(User user)
    {
        var result = await _userRepository.GetByIdAsync(user.Id);
        if (result is null)
            return new Result("User not found");
        await _userRepository.UpdateAsync(user);
        return new Result();
    }

    public async Task<Result<User?>> FindUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user is not null
            ? new Result<User?>(user)
            : new Result<User?>("User not found");
    }

    public virtual async Task<Result> CreateNewUserAsync(User user, string password)
    {
        var result = await FindUserByEmailAsync(user.Email);
        if (result.IsSuccessful)
            return new Result("Email is already registered");
        user.NormalizedEmail = user.Email.Normalize();
        user.Password = _passwordEncryptionService.EncryptPassword(password);
        await _userRepository.InsertAsync(user);
        return new Result();
    }

    public virtual async Task<Result> DeleteAsync(User user)
    {
        var result = await _userRepository.GetByIdAsync(user.Id);
        if (result is null)
            return new Result("User not found");
        await _userRepository.DeleteAsync(user);
        return new Result();
    }

    public IEnumerable<Claim> GetUserClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(TypeUserClaims.Username, user.Username),
            new(TypeUserClaims.Id, user.Id.ToString()),
            new(TypeUserClaims.Email, user.Email)
        };
        claims.AddRange(user.Roles.Select(x => new Claim(TypeUserClaims.Role, x.Name)));
        return claims;
    }
}