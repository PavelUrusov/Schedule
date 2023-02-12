using System.Net;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class WorkMonthService : IWorkMonthService
{
    private readonly IWorkMonthRepository _repository;
    private readonly IWorkObjectService _woService;

    public WorkMonthService(IWorkMonthRepository repository, IWorkObjectService woService)
    {
        _repository = repository;
        _woService = woService;
    }


    public async Task<ResponseBase> AddWorkMonthAsync(RequestAddWorkMonthDto dto, int userId)
    {
        var workObject = await _woService.FindWorkObjectAsync(dto.WorkObject, userId);
        if (workObject.IsUnsuccessful)
            return workObject;

        var parseIsSuccess = TryParseDateString(dto.Date, out var formattedDate);
        if (parseIsSuccess is false)
            return new ResponseBase("Invalid date format", HttpStatusCode.BadRequest);

        var workMonth = await FindWorkMonthByDateAndWorkObjectIdAsync(formattedDate!, dto.WorkObject.WorkObjectId);
        if (workMonth is not null)
            return new ResponseBase("Work month already exist", HttpStatusCode.BadRequest);

        var newWorkMonth = new WorkMonth
        {
            Date = formattedDate!,
            WorkObjectId = dto.WorkObject.WorkObjectId
        };
        await _repository.InsertAsync(newWorkMonth);

        return new ResponseBase();
    }

    protected bool TryParseDateString(string dateInput, out string? formattedDate)
    {
        var parseSuccess = DateTime.TryParse(dateInput, out var parsedDateTime);
        if (!parseSuccess)
        {
            formattedDate = null;
            return parseSuccess;
        }

        formattedDate = parsedDateTime.ToString("MM.yyyy");
        return parseSuccess;
    }


    protected async Task<WorkMonth?> FindWorkMonthByDateAndWorkObjectIdAsync(string date, int workObjectId)
    {
        return await _repository.SingleOrDefaultAsync(wm => wm!.WorkObjectId == workObjectId && wm.Date == date);
    }
}