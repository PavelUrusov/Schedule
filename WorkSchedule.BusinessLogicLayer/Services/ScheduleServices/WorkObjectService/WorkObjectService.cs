using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkMonthDto;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkObjectDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;
using GetWorkObjectDto = WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos.GetWorkObjectDto;

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

    public async Task<ResponseBase> AddWorkObject(AddWorkObjectDto dto, int userId)
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

    public async Task<ResponseBase> GetAllWorkObjectsAsync(int userId)
    {
        var dtos = await _woRepository.CreateQueryable()
            .Include(wo => wo.WorkMonths)
            .Where(wo => wo.UserId == userId)
            .Select(wo => _mapper.Map<WorkObject, DataTransferObjects.Responses.WorkObjectDtos.GetWorkObjectDto>(wo))
            .ToListAsync();

        return new WorkObjectsDtos { Dtos = dtos };
    }

    public async Task<ResponseBase> GetWorkObjectAsync(GetWorkObjectDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.UserId == userId && wo.Id == dto.Id);

        return workObject is null
            ? new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest)
            : _mapper.Map<WorkObject, DataTransferObjects.Responses.WorkObjectDtos.GetWorkObjectDto>(workObject);
    }

    public async Task<ResponseBase> RemoveWorkObjectAsync(GetWorkObjectDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.Id == dto.Id && wo.UserId == userId);
        if (workObject is null)
            return new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest);

        await _woRepository.DeleteAsync(workObject);

        return new ResponseBase();
    }

    public async Task<ResponseBase> AddWorkMonth(AddWorkMonthDto dto, int userId)
    {
        var date = DateOnly.Parse(dto.Date);
        var wo = await _woRepository.FirstOrDefaultAsync(wo =>
            wo != null && wo.UserId == userId && wo.Id == dto.WorkObjectId);
        if (wo is null)
            return new ResponseBase("The Work Object not found", HttpStatusCode.BadRequest);

        var workMonth = new WorkMonth
        {
            Date = date,
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
                    Date = new DateOnly(year, i, 1)
                });

            return list;
        });
        task.Start();

        return await task;
    }
}