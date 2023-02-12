using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation
{
    public class RoleRepository:BaseBaseRepository<Role,int>,IRoleRepository
    {
        public RoleRepository(WorkScheduleDbContext context) : base(context)
        {
        }

        public async Task<Role?> FindByNameAsync(string normalizedName)
        {
            return await _dbSet.SingleOrDefaultAsync(r => r.NormalizedName == normalizedName);
        }
    }
}