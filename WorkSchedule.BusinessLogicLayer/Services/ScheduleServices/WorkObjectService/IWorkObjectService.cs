using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObject;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

public interface IWorkObjectService
{
    Task<ResponseBase> AddWorkObject(AddWorkObjectDto dto,int userId);
    Task<ResponseBase> RemoveWorkObjectAsync(WorkObjectIdDto dto,int userId);
    Task<ResponseBase> GetWorkObjectAsync(WorkObjectIdDto dto, int userId);
    Task<ResponseBase> GetAllWorkObjectsAsync(int userId);
}