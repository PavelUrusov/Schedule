using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;

public class UserManager : IUserManager
{
    private readonly IPasswordEncryptionService _passwordEncryptionService;
    private readonly IUserRepository _userRepository;

    public UserManager(
        IUserRepository userRepository,
        IPasswordEncryptionService passwordEncryptionService)
    {
        _passwordEncryptionService = passwordEncryptionService;
        _userRepository = userRepository;
    }

    public virtual async Task<Result<User?>> FindUserByEmailAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);

        return user is not null
            ? new Result<User?>(user)
            : new Result<User?>("User not found");
    }

    public virtual async Task<Result> UpdateUserAsync(User user)
    {
        var result = await FindUserByIdAsync(user.Id);
        if (result.IsUnsuccessful)
            return result;

        await _userRepository.UpdateAsync(user);

        return new Result();
    }

    public async Task<Result<User?>> FindUserByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);

        return user is not null
            ? new Result<User?>(user)
            : new Result<User?>("User not found");
    }

    public virtual async Task<Result> CreateNewUserAsync(User user, string password)
    {
        user.NormalizedEmail = user.Email.Normalize();
        var result = await FindUserByEmailAsync(user.Email);
        if (result.IsSuccessful)
            return new Result("User is already exist");

        user.Password = _passwordEncryptionService.EncryptPassword(password);
        await _userRepository.InsertAsync(user);

        return new Result();
    }

    public virtual async Task<Result> DeleteAsync(User user)
    {
        var result = await FindUserByIdAsync(user.Id);
        if (result.IsUnsuccessful)
            return result;

        await _userRepository.DeleteAsync(user);

        return new Result();
    }

    public virtual IEnumerable<Claim> GetUserClaims(User user)
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