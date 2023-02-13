using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IScheduleManager
{
    Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto, int userId);
}