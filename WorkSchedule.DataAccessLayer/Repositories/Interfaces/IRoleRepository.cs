using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.Interfaces;

public interface IRoleRepository : IBaseRepository<Role, int>
{
    Task<Role?> FindByNameAsync(string normalizedName);
}