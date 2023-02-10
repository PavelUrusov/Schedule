using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkObjectService
{
    Task<ResponseBase> AddWorkObject(RequestAddWorkObjectDto dto, int userId);
    Task<ResponseBase> GetListWorkObjectAsync(int userId);
    Task<ResponseBase> GetWorkObjectAsync(RequestGetWorkObjectDto dto, int userId);
    Task<ResponseBase> RemoveWorkObjectAsync(RequestRemoveWorkObjectDto dto, int userId);
    Task<ResponseBase> AddWorkMonth(RequestAddWorkMonthDto dto, int userId);
}