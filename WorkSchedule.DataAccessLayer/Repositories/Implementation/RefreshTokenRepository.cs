using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class RefreshTokenRepository : BaseBaseRepository<RefreshToken, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(WorkScheduleDbContext context) : base(context)
    {
    }
}