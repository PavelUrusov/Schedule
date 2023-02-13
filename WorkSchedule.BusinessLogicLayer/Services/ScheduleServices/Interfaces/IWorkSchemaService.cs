using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;

public interface IWorkSchemaService
{
    Task<ResponseBase> AddWorkSchemaAsync(RequestAddWorkSchemaDto dto, int userId);
    Task<ResponseBase> FindRangeWorkSchemaAsync(int userId);
    Task<ResponseBase> DeleteWorkSchemaAsync(RequestRemoveWorkSchemaDto dto, int userId);
    Task<ResponseBase> FindWorkSchemaAsync(RequestGetWorkSchemaDto dto, int userId);
}