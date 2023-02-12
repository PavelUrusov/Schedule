using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class UserRepository : BaseBaseRepository<User, int>, IUserRepository
{
    public UserRepository(WorkScheduleDbContext context) : base(context)
    {
    }


    public async Task<User?> FindByEmailAsync(string normalizedEmail)
    {
        return await _dbSet.SingleOrDefaultAsync(x => x.NormalizedEmail == normalizedEmail);
    }
}