using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User, int>
{
    Task<User?> FindByEmailAsync(string email);
}