using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.RoleManager;

public interface IRoleManager
{
    Task<Result> CreateRoleAsync(Role role);
    Task<Result<Role?>> FindByNameAsync(string name);
    Task<Result> UpdateRoleAsync(Role role);
    Task<Result> DeleteRoleAsync(int id);
}