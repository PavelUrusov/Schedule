using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.WorkSchedule;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

public class ScheduleManager : IScheduleManager
{
    private readonly IWorkScheduleRepository<Schedule, int> _sRepository;
    private readonly EmployeeManager _empManager;

    public ScheduleManager(IWorkScheduleRepository<Schedule, int> sRepository, EmployeeManager empManager)
    {
        _sRepository = sRepository;
        _empManager = empManager;
    }

    public Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto, int userId)
    {
        
        throw new NotImplementedException();
    }
}

public record RequestAddScheduleDto
{
    [Required] [DataType(DataType.Date)] public string ScheduleStart { get; init; } = null!;

    [Required] [Range(1, int.MaxValue)] public int EmployeeId { get; init; }

    [Required] [Range(1, int.MaxValue)] public int WorkSchemaId { get; init; }

    [Required] [Range(1, int.MaxValue)] public int WorkMonthId { get; init; }
}