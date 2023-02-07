using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkMonthDto;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

public interface IWorkObjectService
{
    Task<ResponseBase> AddWorkObject(AddWorkObjectDto dto,int userId);
    Task<ResponseBase> RemoveWorkObjectAsync(GetWorkObjectDto dto,int userId);
    Task<ResponseBase> GetWorkObjectAsync(GetWorkObjectDto dto, int userId);
    Task<ResponseBase> GetAllWorkObjectsAsync(int userId);
    Task<ResponseBase> AddWorkMonth(AddWorkMonthDto dto, int userId);
}