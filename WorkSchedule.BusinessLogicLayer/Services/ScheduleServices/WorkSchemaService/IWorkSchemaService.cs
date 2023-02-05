using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkSchema;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkSchemaService;

public interface IWorkSchemaService
{
    Task<ResponseBase> AddWorkSchemaAsync(AddWorkSchemaDto dto, int userId);
    Task<ResponseBase> DeleteWorkSchemaAsync(DeleteWorkSchemaDto dto, int userId);
    Task<ResponseBase> GetListWorkSchemaAsync(int userId);
}