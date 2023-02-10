using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.ScheduleDtos;

public record BaseScheduleDto
{
    public string ScheduleStart { get; set; } = null!;
    public BaseWorkSchemaDto WorkSchema { get; init; } = null!;
    public BaseEmployeeDto Employee { get; init; } = null!;
    public BaseWorkMonthDto WorkMonth { get; init; } = null!;
}