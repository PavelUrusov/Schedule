using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkSchemaDtos;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkSchemaService;

public class WorkSchemaService : IWorkSchemaService
{
    private readonly IMapper _mapper;
    private readonly IWorkScheduleRepository<WorkSchema, int> _wsRepository;

    public WorkSchemaService(IWorkScheduleRepository<WorkSchema, int> wsRepository, IMapper mapper)
    {
        _wsRepository = wsRepository;
        _mapper = mapper;
    }

    public async Task<ResponseBase> AddWorkSchemaAsync(AddWorkSchemaDto dto, int userId)
    {
        var workSchema = new WorkSchema
        {
            Name = dto.Name,
            StartTime = TimeOnly.Parse(dto.StartTime),
            EndTime = TimeOnly.Parse(dto.EndTime),
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
            .Select(wo => _mapper.Map<WorkSchema, GetWorkSchemaDto>(wo))
            .ToListAsync();

        return new GetListWorkSchemaDto { Dtos = dtos };
    }

    public async Task<ResponseBase> DeleteWorkSchemaAsync(DeleteWorkSchemaDto dto, int userId)
    {
        var result =
            await _wsRepository.FirstOrDefaultAsync(ws => ws != null && ws.Id == dto.Id && ws.UserId == userId);
        if (result is null)
            return new ResponseBase("WorkSchema not found", HttpStatusCode.BadRequest);

        await _wsRepository.DeleteAsync(result);

        return new ResponseBase();
    }
}