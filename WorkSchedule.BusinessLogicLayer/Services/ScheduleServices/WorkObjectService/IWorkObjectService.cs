using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

public interface IWorkObjectService
{
    Task<ResponseBase> AddWorkObject(RequestAddWorkObjectDto dto, int userId);
    Task<ResponseBase> GetListWorkObjectAsync(int userId);
    Task<ResponseBase> GetWorkObjectAsync(RequestGetWorkObjectDto dto, int userId);
    Task<ResponseBase> RemoveWorkObjectAsync(RequestRemoveWorkObjectDto dto, int userId);
    Task<ResponseBase> AddWorkMonth(RequestAddWorkMonthDto dto, int userId);
}