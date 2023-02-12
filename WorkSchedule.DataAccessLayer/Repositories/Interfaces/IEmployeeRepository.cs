using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee, int>
{
    Task<List<Employee>> FindRangeEmployeeByWorkObjectId(int id);
}