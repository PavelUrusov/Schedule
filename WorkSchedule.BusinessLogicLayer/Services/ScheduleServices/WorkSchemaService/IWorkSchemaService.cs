using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkSchemaService;

public interface IWorkSchemaService
{
    Task<ResponseBase> AddWorkSchemaAsync(RequestAddWorkSchemaDto dto, int userId);
    Task<ResponseBase> GetListWorkSchemaAsync(int userId);
    Task<ResponseBase> DeleteWorkSchemaAsync(RequestRemoveWorkSchemaDto dto, int userId);
}