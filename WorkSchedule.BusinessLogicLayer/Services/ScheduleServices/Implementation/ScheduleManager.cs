using System.ComponentModel.DataAnnotations;
using WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Repositories.Interfaces;

namespace WorkSchedule.BusinessLogicLayer.Services.ScheduleServices.Implementation;

//TODO
public class ScheduleManager : IScheduleManager
{
    private readonly IScheduleRepository _repository;
    private readonly EmployeeManager _empManager;

    public ScheduleManager(IScheduleRepository repository, EmployeeManager empManager)
    {
        _repository = repository;
        _empManager = empManager;
    }
    //TODO ДОДЕЛАТЬ ЕГО УЖЕ И СДЕЛАТЬ ВСЕ ТЕСТЫ НА ВСЕ СЕРВИСЫ.
    public Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto, int userId)
    {
        
        throw new NotImplementedException();
    }

    public Task<ResponseBase> AddScheduleAsync(RequestAddScheduleDto dto)
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