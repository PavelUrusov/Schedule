using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkObjectService
{
    Task<ResponseBase> AddWorkObject(RequestAddWorkObjectDto dto, int userId);
    Task<ResponseBase> GetListWorkObjectAsync(int userId);
    Task<ResponseBase> FindWorkObjectAsync(RequestGetWorkObjectDto dto, int userId);
    Task<ResponseBase> RemoveWorkObjectAsync(RequestRemoveWorkObjectDto dto, int userId);
}