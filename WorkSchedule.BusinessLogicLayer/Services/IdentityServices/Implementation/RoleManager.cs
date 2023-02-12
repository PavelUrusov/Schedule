using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;

public class RoleManager : IRoleManager
{
    private readonly IRoleRepository _roleRepository;

    public RoleManager(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public virtual async Task<Result> CreateRoleAsync(Role role)
    {
        role.NormalizedName = role.Name.Normalize();
        var result = await FindByNameAsync(role.NormalizedName);

        if (result.IsSuccessful)
            return new Result { IsSuccessful = false, ErrorMessage = "Role already exists" };

        await _roleRepository.InsertAsync(role);

        return new Result();
    }

    public virtual async Task<Result<Role?>> FindByNameAsync(string name)
    {
        var normalizedName = name.Normalize();
        var role = await _roleRepository.FindByNameAsync(normalizedName);

        return role is not null
            ? new Result<Role?>(role)
            : new Result<Role?>("Role not found");
    }

    public virtual async Task<Result> UpdateRoleAsync(Role role)
    {
        var result = await FindByIdAsync(role.Id);
        if (result.IsUnsuccessful)
            return result;

        var existingRole = result.Data!;
        existingRole.Name = role.Name;
        existingRole.NormalizedName = role.Name.Normalize();
        await _roleRepository.UpdateAsync(existingRole);

        return new Result();
    }

    public virtual async Task<Result> DeleteRoleAsync(int id)
    {
        var result = await FindByIdAsync(id);
        if (result.IsUnsuccessful)
            return result;

        var role = result.Data!;
        await _roleRepository.DeleteAsync(role);

        return new Result();
    }

    public async Task<Result<Role?>> FindByIdAsync(int roleId)
    {
        var role = await _roleRepository.FindByIdAsync(roleId);

        return role is null
            ? new Result<Role?>("Role doesn't exist")
            : new Result<Role?>(role);
    }
}