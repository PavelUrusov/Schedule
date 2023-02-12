using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IScheduleManager
{
    public Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto);
}