using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkMonthService
{
    string CurrentFormattedWorkMonth => DateTime.UtcNow.ToString("MM.yyyy");

    Task<ResponseBase> AddWorkMonthAsync(RequestAddWorkMonthDto dto, int userId);
    Task<ResponseBase> FindWorkMonthAsync(RequestGetWorkMonthDto dto, int userId);
}