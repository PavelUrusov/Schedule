using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

//TODO
public class ScheduleManager : IScheduleManager
{
    private readonly IEmployeeManager _empManager;
    private readonly IMapper _mapper;
    private readonly IScheduleRepository _repository;
    private readonly IWorkMonthService _wmService;
    private readonly IWorkObjectService _woService;
    private readonly IWorkSchemaService _wsService;

    public ScheduleManager(
        IScheduleRepository repository,
        IWorkMonthService wmService,
        IWorkSchemaService wsService,
        IEmployeeManager empManager,
        IWorkObjectService woService,
        IMapper mapper)
    {
        _repository = repository;
        _wmService = wmService;
        _wsService = wsService;
        _empManager = empManager;
        _woService = woService;
        _mapper = mapper;
    }

    //TODO ДОДЕЛАТЬ ЕГО УЖЕ И СДЕЛАТЬ ВСЕ ТЕСТЫ НА ВСЕ СЕРВИСЫ.
    public async Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto, int userId)
    {
        var workMonth =
            await _wmService.FindWorkMonthAsync(new RequestGetWorkMonthDto { Id = dto.WorkMonthId }, userId);
        if (workMonth.IsUnsuccessful)
            return new ResponseBase("Work Month not found", HttpStatusCode.BadRequest);

        var employee =
            await _empManager.FindEmployeeAsync(new RequestGetEmployeeDto { EmployeeId = dto.EmployeeId }, userId);
        if (employee.IsUnsuccessful)
            return new ResponseBase("Employee not found", HttpStatusCode.BadRequest);

        var workSchema =
            await _wsService.FindWorkSchemaAsync(new RequestGetWorkSchemaDto { Id = dto.WorkSchemaId }, userId);
        if (workSchema.IsUnsuccessful)
            return new ResponseBase("Work Schema not found", HttpStatusCode.BadRequest);

        var resultParse = DateOnly.TryParse(dto.ScheduleStart, out var scheduleStart);
        if (resultParse is false)
            return new ResponseBase("Invalid date schedule start", HttpStatusCode.BadRequest);

        var schedule = new Schedule
        {
            ScheduleStart = dto.ScheduleStart,
            EmployeeId = dto.EmployeeId,
            WorkMonthId = dto.WorkMonthId,
            WorkSchemaId = dto.WorkSchemaId
        };
        await _repository.InsertAsync(schedule);

        return new ResponseBase();
    }

    public async Task<ResponseBase> GetScheduleAsync(RequestGetScheduleDto dto, int userId)
    {
        var schedule = await FindScheduleByIdAsync(dto.Id, userId);

        return schedule is null
            ? new ResponseBase("Schedule not found", HttpStatusCode.BadRequest)
            : _mapper.Map<Schedule, ResponseGetScheduleDto>(schedule);
    }

    public async Task<ResponseBase> GetRangeSchedulesAsync(RequestGetRangeSchedulesDto dto, int userId)
    {
        var result = await _woService.FindWorkObjectAsync(
                new RequestGetWorkObjectDto { WorkObjectId = dto.WorkObjectId }, userId);
        if (result.IsUnsuccessful)
            return result;

        var schedules = await FindRangeSchedulesAsync(dto.WorkMonthId, userId);

        return _mapper.Map<IEnumerable<Schedule>, ResponseGetRangeSchedulesDto>(schedules);
    }

    protected async Task<Schedule?> FindScheduleByIdAsync(int id, int userId)
    {
        return await _repository.SingleOrDefaultAsync(s => s!.WorkSchema.UserId == userId && s.Id == id);
    }

    protected async Task<IEnumerable<Schedule>> FindRangeSchedulesAsync(int workMonthId, int userId)
    {
        return await _repository
            .AsQueryable()
            .Where(s => s.WorkSchema.UserId == userId && s.WorkMonthId == workMonthId)
            .ToListAsync();
    }
}