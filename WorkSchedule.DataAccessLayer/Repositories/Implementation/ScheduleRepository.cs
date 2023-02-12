using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class ScheduleRepository : BaseBaseRepository<Schedule, int>, IScheduleRepository
{
    public ScheduleRepository(WorkScheduleDbContext context) : base(context)
    {
    }
}