using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObject;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkObject;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.WorkObjectService;

public class WorkObjectService : IWorkObjectService
{
    private readonly IMapper _mapper;
    private readonly IWorkScheduleRepository<WorkObject, int> _woRepository;

    public WorkObjectService(IWorkScheduleRepository<WorkObject, int> woRepository, IMapper mapper)
    {
        _woRepository = woRepository;
        _mapper = mapper;
    }

    public async Task<ResponseBase> AddWorkObject(AddWorkObjectDto dto, int userId)
    {
        var result =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.UserId == userId && wo.Name == dto.Name);
        if (result is not null)
            return new ResponseBase("The Work Object with that name already exist", HttpStatusCode.BadRequest);

        var workObject = new WorkObject { Name = dto.Name, UserId = userId };
        await _woRepository.InsertAsync(workObject);

        return new ResponseBase();
    }

    public async Task<ResponseBase> GetAllWorkObjectsAsync(int userId)
    {
        var dtos = await _woRepository.CreateQueryable()
            .Where(wo => wo.UserId == userId)
            .Select(wo => new WorkObjectDto { Id = wo.Id, Name = wo.Name })
            .ToListAsync();

        return new WorkObjectsDtos { Dtos = dtos };
    }

    public async Task<ResponseBase> GetWorkObjectAsync(WorkObjectIdDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.UserId == userId && wo.Id == dto.Id);

        return workObject is null
            ? new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest)
            : new WorkObjectDto { Id = workObject.Id, Name = workObject.Name };
    }

    public async Task<ResponseBase> RemoveWorkObjectAsync(WorkObjectIdDto dto, int userId)
    {
        var workObject =
            await _woRepository.FirstOrDefaultAsync(wo => wo != null && wo.Id == dto.Id && wo.UserId == userId);
        if (workObject is null)
            return new ResponseBase("The workObjectId not found", HttpStatusCode.BadRequest);

        await _woRepository.DeleteAsync(workObject);

        return new ResponseBase();
    }
}