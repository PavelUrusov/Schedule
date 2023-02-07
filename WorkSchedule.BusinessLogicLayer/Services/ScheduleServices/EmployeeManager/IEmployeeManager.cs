using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.EmployeeManager;

public interface IEmployeeManager
{
    Task<ResponseBase> AddEmployeeAsync(AddEmployeeDto dto, int userId);
    Task<ResponseBase> AddEmployeeListAsync(AddListEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveEmployeeAsync(RemoveEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveListEmployeeAsync(RemoveListEmployeeDto dto, int userId);
    Task<ResponseBase> GetListEmployeeWithSchedulesAsync(GetEmployeeWithSchedulesDto dto, int userId);

}