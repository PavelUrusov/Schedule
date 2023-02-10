using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IScheduleManager
{
    public Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto);
}