using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class WorkSchemaService : IWorkSchemaService
{
    private readonly IMapper _mapper;
    private readonly IWorkSchemaRepository _repository;

    public WorkSchemaService(IWorkSchemaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase> AddWorkSchemaAsync(RequestAddWorkSchemaDto dto, int userId)
    {
        var workSchema = new WorkSchema
        {
            Name = dto.Name,
            StartTime = FormattedTime(dto.StartTime),
            EndTime = FormattedTime(dto.EndTime),
            Scheme = dto.Scheme,
            UserId = userId
        };
        await _repository.InsertAsync(workSchema);

        return new ResponseBase();
    }

    public async Task<ResponseBase> FindRangeWorkSchemaAsync(int userId)
    {
        var workSchemas = await FindRangeWorkSchemasByUserId(userId);

        return _mapper.Map<IEnumerable<WorkSchema>, ResponseListWorkSchemaDto>(workSchemas);
    }

    public async Task<ResponseBase> DeleteWorkSchemaAsync(RequestRemoveWorkSchemaDto dto, int userId)
    {
        var result = await FindWorkSchemaByIdAndUserId(dto.Id, userId);
        if (result is null)
            return new ResponseBase("WorkSchema not found", HttpStatusCode.BadRequest);

        await _repository.DeleteAsync(result);

        return new ResponseBase();
    }

    public async Task<ResponseBase> FindWorkSchemaAsync(RequestGetWorkSchemaDto dto, int userId)
    {
        var workSchema = await FindWorkSchemaByIdAndUserId(dto.Id, userId);

        return workSchema is null
            ? new ResponseBase("Work schema not found", HttpStatusCode.BadRequest)
            : _mapper.Map<WorkSchema, ResponseGetWorkSchemaDto>(workSchema);
    }

    protected string FormattedTime(string time)
    {
        return TimeOnly.Parse(time).ToString("t");
    }

    protected async Task<List<WorkSchema>> FindRangeWorkSchemasByUserId(int userId)
    {
        return await _repository.AsQueryable().Where(wo => wo.UserId == userId).ToListAsync();
    }

    protected async Task<WorkSchema?> FindWorkSchemaByIdAndUserId(int id, int userId)
    {
        return await _repository.SingleOrDefaultAsync(ws => ws!.Id == id && ws.UserId == userId);
    }
}