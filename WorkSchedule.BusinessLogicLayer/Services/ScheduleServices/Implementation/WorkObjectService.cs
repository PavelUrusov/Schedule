using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class WorkObjectService : IWorkObjectService
{
    private readonly IMapper _mapper;
    private readonly IWorkObjectRepository _repository;
    private readonly IWorkMonthService _wmService;

    public WorkObjectService(IWorkObjectRepository repository, IMapper mapper,
        IWorkMonthService wmService)
    {
        _repository = repository;
        _mapper = mapper;
        _wmService = wmService;
    }

    public async Task<ResponseBase> AddWorkObject(RequestAddWorkObjectDto dto, int userId)
    {
        var result = await FindWorkObjectByNameAsync(dto.Name, userId);
        if (result is not null)
            return new ResponseBase("Work Object with that name already exist", HttpStatusCode.BadRequest);

        var workObject = new WorkObject
        {
            Name = dto.Name,
            UserId = userId,
            WorkMonths = new List<WorkMonth> { new() { Date = _wmService.CurrentFormattedWorkMonth } }
        };
        await _repository.InsertAsync(workObject);

        return new ResponseBase();
    }

    public async Task<ResponseBase> GetListWorkObjectAsync(int userId)
    {
        var workObjects = await FindRangeWorkObjectsByUserIdAsync(userId);
        var result = _mapper.Map<IEnumerable<WorkObject>, ResponseListWorkObjectDto>(workObjects);

        return result;
    }

    public async Task<ResponseBase> FindWorkObjectAsync(RequestGetWorkObjectDto dto, int userId)
    {
        var workObject = await FindWorkObjectByIdAndUserIdAsync(dto.WorkObjectId, userId);

        return workObject is null
            ? new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest)
            : new ResponseWorkObjectDto { WorkObject = _mapper.Map<WorkObject, BaseWorkObjectDto>(workObject) };
    }

    public async Task<ResponseBase> RemoveWorkObjectAsync(RequestRemoveWorkObjectDto dto, int userId)
    {
        var workObject = await FindWorkObjectByIdAndUserIdAsync(dto.WorkObjectId, userId);
        if (workObject is null)
            return new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest);

        await _repository.DeleteAsync(workObject);

        return new ResponseBase();
    }


    protected async Task<WorkObject?> FindWorkObjectByIdAndUserIdAsync(int id, int userId)
    {
        return await _repository.SingleOrDefaultAsync(wo => wo!.UserId == userId && wo.Id == id);
    }

    protected async Task<WorkObject?> FindWorkObjectByNameAsync(string name, int userId)
    {
        return await _repository.FirstOrDefaultAsync(wo => wo!.UserId == userId && wo.Name == name);
    }

    protected async Task<List<WorkObject>> FindRangeWorkObjectsByUserIdAsync(int userId)
    {
        return await _repository.AsQueryable().Where(wo => wo.UserId == userId).ToListAsync();
    }
}