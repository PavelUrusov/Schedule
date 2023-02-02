using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.RoleManager;

public class RoleManager : IRoleManager
{
    private readonly IWorkScheduleRepository<Role, int> _roleRepository;

    public RoleManager(IWorkScheduleRepository<Role, int> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public virtual async Task<Result> CreateRoleAsync(Role role)
    {
        role.NormalizedName = role.Name.Normalize();
        var result = await FindByNameAsync(role.Name);
        if (result.IsSuccessful)
            return new Result { IsSuccessful = false, ErrorMessage = "Role already exists" };

        await _roleRepository.InsertAsync(role);

        return new Result();
    }

    public virtual async Task<Result<Role?>> FindByNameAsync(string name)
    {
        var normalizedName = name.Normalize();
        var role = await _roleRepository.CreateQueryable()
            .SingleOrDefaultAsync(x => x.NormalizedName == normalizedName);

        return role is not null
            ? new Result<Role?>(role)
            : new Result<Role?>("Role not found");
    }

    public virtual async Task<Result> UpdateRoleAsync(Role role)
    {
        var existingRole = await _roleRepository.GetByIdAsync(role.Id);
        if (existingRole is null)
            return new Result("Role does not exist");

        existingRole.Name = role.Name;
        existingRole.NormalizedName = role.Name.Normalize();
        await _roleRepository.UpdateAsync(existingRole);

        return new Result();
    }

    public virtual async Task<Result> DeleteRoleAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);
        if (role is null)
            return new Result("Role does not exist");

        await _roleRepository.DeleteAsync(role);

        return new Result();
    }
}