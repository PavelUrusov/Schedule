using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IScheduleManager
{
    Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto, int userId);
    Task<ResponseBase> GetScheduleAsync(RequestGetScheduleDto dto, int userId);
    Task<ResponseBase> GetRangeSchedulesAsync(RequestGetRangeSchedulesDto dto, int userId);
}