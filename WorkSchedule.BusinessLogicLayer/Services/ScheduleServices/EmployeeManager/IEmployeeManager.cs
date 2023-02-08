using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.EmployeeManager;

public interface IEmployeeManager
{
    Task<ResponseBase> AddEmployeeAsync(RequestAddEmployeeDto dto, int userId);
    Task<ResponseBase> AddEmployeeListAsync(RequestAddListEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveEmployeeAsync(RequestRemoveEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveListEmployeeAsync(RequestRemoveListEmployeeDto dto, int userId);
}