using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

public class WorkObjectService : IWorkObjectService
{
    private readonly IMapper _mapper;
    private readonly IWorkScheduleRepository<WorkMonth, int> _wmRepository;
    private readonly IWorkScheduleRepository<WorkObject, int> _woRepository;

    public WorkObjectService(IWorkScheduleRepository<WorkObject, int> woRepository, IMapper mapper,
        IWorkScheduleRepository<WorkMonth, int> wmRepository)
    {
        _woRepository = woRepository;
        _mapper = mapper;
        _wmRepository = wmRepository;
    }

    public async Task<ResponseBase> AddWorkObject(RequestAddWorkObjectDto dto, int userId)
    {
        var result =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.UserId == userId && wo.Name == dto.Name);
        if (result is not null)
            return new ResponseBase("The Work Object with that name already exist", HttpStatusCode.BadRequest);

        var workYear = await GenerateWorkYearAsync(DateTime.Now.Year);
        var workObject = new WorkObject { Name = dto.Name, UserId = userId, WorkMonths = workYear };
        await _woRepository.InsertAsync(workObject);

        return new ResponseBase();
    }

    public async Task<ResponseBase> GetListWorkObjectAsync(int userId)
    {
        var dtos = await _woRepository.CreateQueryable()
            .Where(wo => wo.UserId == userId)
            .Select(wo => _mapper.Map<WorkObject, BaseWorkObjectDto>(wo))
            .ToListAsync();

        return new ResponseListWorkObjectDto { WorkObjects = dtos };
    }

    public async Task<ResponseBase> GetWorkObjectAsync(RequestGetWorkObjectDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(
                wo => wo != null && wo.UserId == userId && wo.Id == dto.WorkObjectId);

        return workObject is null
            ? new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest)
            : new ResponseWorkObjectDto { WorkObject = _mapper.Map<WorkObject, BaseWorkObjectDto>(workObject) };
    }

    public async Task<ResponseBase> RemoveWorkObjectAsync(RequestRemoveWorkObjectDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(
                wo => wo != null && wo.Id == dto.WorkObjectId && wo.UserId == userId);
        if (workObject is null)
            return new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest);

        await _woRepository.DeleteAsync(workObject);

        return new ResponseBase();
    }

    public async Task<ResponseBase> AddWorkMonth(RequestAddWorkMonthDto dto, int userId)
    {
        var formattedDate = DateOnly.Parse(dto.Date).ToString("MM.yyyy");
        var wo = await _woRepository.FirstOrDefaultAsync(wo =>
            wo != null && wo.UserId == userId && wo.Id == dto.WorkObjectId);
        if (wo is null)
            return new ResponseBase("The Work Object not found", HttpStatusCode.BadRequest);

        var workMonth = new WorkMonth
        {
            Date = formattedDate,
            WorkObjectId = dto.WorkObjectId
        };
        await _wmRepository.InsertAsync(workMonth);

        return new ResponseBase();
    }

    private async Task<IEnumerable<WorkMonth>> GenerateWorkYearAsync(int year)
    {
        var task = new Task<List<WorkMonth>>(() =>
        {
            var list = new List<WorkMonth>(13);
            for (var i = 1; i < 13; ++i)
                list.Add(new WorkMonth
                {
                    Date = new DateOnly(year, i, 1).ToString("MM.yyyy")
                });

            return list;
        });
        task.Start();

        return await task;
    }
}