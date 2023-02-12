using Microsoft.EntityFrameworkCore;
using WorkSchedule.DataAccessLayer.Database;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.DataAccessLayer.Repositories.Implementation
{
    public class EmployeeRepository:BaseBaseRepository<Employee,int>,IEmployeeRepository
    {
        public EmployeeRepository(WorkScheduleDbContext context) : base(context)
        {
        }

        public async Task<List<Employee>> FindRangeEmployeeByWorkObjectId(int id)
        {
            return await _dbSet.AsQueryable().Where(e=>e.WorkObjectId == id).ToListAsync();
        }
    }
}