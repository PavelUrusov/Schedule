using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkMonthService
{
    string CurrentFormattedWorkMonth => DateTime.UtcNow.ToString("MM.yyyy");

    Task<ResponseBase> AddWorkMonthAsync(RequestAddWorkMonthDto dto, int userId);
}