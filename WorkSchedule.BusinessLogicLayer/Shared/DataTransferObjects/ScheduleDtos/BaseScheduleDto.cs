using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

public record BaseScheduleDto : IMapWith<Schedule>
{
    public int Id { get; init; }
    public string ScheduleStart { get; set; } = null!;
    public BaseWorkSchemaDto WorkSchema { get; init; } = null!;
    public BaseEmployeeDto Employee { get; init; } = null!;
    public BaseWorkMonthDto WorkMonth { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Schedule, BaseScheduleDto>()
            .ForMember(dto => dto.ScheduleStart, opt => opt.MapFrom(s => s.ScheduleStart))
            .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id));

    }

}