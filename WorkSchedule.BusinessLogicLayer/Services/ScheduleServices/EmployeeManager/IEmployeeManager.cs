using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Employee;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.EmployeeManager;

public interface IEmployeeManager
{
    public Task<ResponseBase> AddEmployeeAsync(AddEmployeeDto dto, int userId);
    public Task<ResponseBase> AddEmployeeListAsync(AddListEmployeeDto dto, int userId);
}