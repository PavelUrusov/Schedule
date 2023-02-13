using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IEmployeeManager
{
    Task<ResponseBase> AddEmployeeAsync(RequestAddEmployeeDto dto, int userId);
    Task<ResponseBase> AddEmployeeListAsync(RequestAddListEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveEmployeeAsync(RequestRemoveEmployeeDto dto, int userId);
    Task<ResponseBase> RemoveListEmployeeAsync(RequestRemoveListEmployeeDto dto, int userId);
    Task<ResponseBase> FindEmployeeAsync(RequestGetEmployeeDto dto, int userId);
    Task<ResponseBase> GetListEmployeeAsync(RequestGetWorkObjectDto dto, int userId);
}