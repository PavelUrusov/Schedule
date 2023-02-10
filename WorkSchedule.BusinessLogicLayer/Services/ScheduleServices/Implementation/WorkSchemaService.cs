using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class WorkSchemaService : IWorkSchemaService
{
    private readonly IMapper _mapper;
    private readonly IWorkScheduleRepository<WorkSchema, int> _wsRepository;

    public WorkSchemaService(IWorkScheduleRepository<WorkSchema, int> wsRepository, IMapper mapper)
    {
        _wsRepository = wsRepository;
        _mapper = mapper;
    }

    public async Task<ResponseBase> AddWorkSchemaAsync(RequestAddWorkSchemaDto dto, int userId)
    {
        var formattedStartTime = TimeOnly.Parse(dto.StartTime).ToString("t");
        var formattedEndTime = TimeOnly.Parse(dto.StartTime).ToString("t");
        var workSchema = new WorkSchema
        {
            Name = dto.Name,
            StartTime = formattedStartTime,
            EndTime = formattedEndTime,
            Scheme = dto.Scheme,
            UserId = userId
        };
        await _wsRepository.InsertAsync(workSchema);

        return new ResponseBase();
    }

    public async Task<ResponseBase> GetListWorkSchemaAsync(int userId)
    {
        var dtos = await _wsRepository
            .CreateQueryable()
            .Where(wo => wo.UserId == userId)
            .Select(wo => _mapper.Map<WorkSchema, BaseWorkSchemaDto>(wo))
            .ToListAsync();

        return new ResponseListWorkSchemaDto { WorkSchemas = dtos };
    }

    public async Task<ResponseBase> DeleteWorkSchemaAsync(RequestRemoveWorkSchemaDto dto, int userId)
    {
        var result =
            await _wsRepository.FirstOrDefaultAsync(ws => ws!.Id == dto.Id && ws.UserId == userId);
        if (result is null)
            return new ResponseBase("WorkSchema not found", HttpStatusCode.BadRequest);

        await _wsRepository.DeleteAsync(result);

        return new ResponseBase();
    }
}