using System.Security.Claims;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;

public interface IUserManager
{
    Task<Result<User?>> FindUserByEmailAsync(string email);
    Task<Result> CreateNewUserAsync(User user, string password);
    Task<Result> DeleteAsync(User user);
    Task<Result> UpdateUserAsync(User user);
    Task<Result<User?>> FindUserByIdAsync(int id);
    IEnumerable<Claim> GetUserClaims(User user);
}