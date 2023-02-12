using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class WorkObjectRepository : BaseBaseRepository<WorkObject, int>, IWorkObjectRepository
{
    public WorkObjectRepository(WorkScheduleDbContext context) : base(context)
    {
    }

}