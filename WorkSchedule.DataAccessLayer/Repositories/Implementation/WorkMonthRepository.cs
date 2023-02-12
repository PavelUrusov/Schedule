using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class WorkMonthRepository : BaseBaseRepository<WorkMonth, int>, IWorkMonthRepository
{
    public WorkMonthRepository(WorkScheduleDbContext context) : base(context)
    {
    }
}