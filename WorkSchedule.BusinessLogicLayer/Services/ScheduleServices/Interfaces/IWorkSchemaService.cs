using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkSchemaService
{
    Task<ResponseBase> AddWorkSchemaAsync(RequestAddWorkSchemaDto dto, int userId);
    Task<ResponseBase> GetListWorkSchemaAsync(int userId);
    Task<ResponseBase> DeleteWorkSchemaAsync(RequestRemoveWorkSchemaDto dto, int userId);
}