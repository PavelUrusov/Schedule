using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation;

public class WorkSchemaRepository : BaseBaseRepository<WorkSchema, int>, IWorkSchemaRepository
{
    public WorkSchemaRepository(WorkScheduleDbContext context) : base(context)
    {
    }
}