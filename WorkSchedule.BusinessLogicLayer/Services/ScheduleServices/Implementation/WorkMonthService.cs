using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class WorkMonthService : IWorkMonthService
{
    private readonly IMapper _mapper;
    private readonly IWorkMonthRepository _repository;

    public WorkMonthService(IWorkMonthRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase> AddWorkMonthAsync(RequestAddWorkMonthDto dto, int userId)
    {
        var parseIsSuccess = TryParseDateString(dto.Date, out var formattedDate);
        if (parseIsSuccess is false)
            return new ResponseBase("Invalid date format", HttpStatusCode.BadRequest);

        var monthIsAlreadyExist = await WorkMonthIsAlreadyExist(formattedDate!, dto.WorkObject.WorkObjectId, userId);
        if (monthIsAlreadyExist is true)
            return new ResponseBase("Work month already exist", HttpStatusCode.BadRequest);

        var newWorkMonth = new WorkMonth
        {
            Date = formattedDate!,
            WorkObjectId = dto.WorkObject.WorkObjectId
        };
        await _repository.InsertAsync(newWorkMonth);

        return new ResponseBase();
    }

    public async Task<ResponseBase> FindWorkMonthAsync(RequestGetWorkMonthDto dto, int userId)
    {
        var workMonth = await FindWorkMonthByIdAndUserIdAsync(dto.Id, userId);

        return workMonth is null
            ? new ResponseBase("Work Month not found", HttpStatusCode.BadRequest)
            : _mapper.Map<WorkMonth, ResponseGetWorkMonthDto>(workMonth);
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

    protected async Task<WorkMonth?> FindWorkMonthByIdAndUserIdAsync(int id, int userId)
    {
        return await _repository.SingleOrDefaultAsync(wm => wm!.Id == id && wm.WorkObject.UserId == userId);
    }

    protected async Task<WorkMonth?> FindWorkMonthByDateAndWorkObjectIdAsync(string date, int workObjectId)
    {
        return await _repository.SingleOrDefaultAsync(wm => wm!.WorkObjectId == workObjectId && wm.Date == date);
    }

    protected async Task<bool> WorkMonthIsAlreadyExist(string date, int workObjectId, int userId)
    {
        return await _repository
            .AsQueryable()
            .Include(wm => wm.WorkObject)
            .AnyAsync(wm => wm.WorkObject.UserId == userId
                            && wm.WorkObjectId == workObjectId
                            && wm.Date == date);
    }
}