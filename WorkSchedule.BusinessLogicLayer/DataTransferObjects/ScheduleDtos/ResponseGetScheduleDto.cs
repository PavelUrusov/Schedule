using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.ScheduleDtos;

public record ResponseGetScheduleDto : ResponseBase, IMapWith<Schedule>
{
    public int Id { get; init; }
    public string ScheduleStart { get; init; } = null!;
    public BaseEmployeeDto Employee { get; init; } = null!;
    public BaseWorkMonthDto WorkMonth { get; init; } = null!;
    public BaseWorkSchemaDto WorkSchema { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Schedule, ResponseGetScheduleDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.ScheduleStart, opt => opt.MapFrom(x => x.ScheduleStart))
            .ForMember(dto => dto.Employee, opt => opt.MapFrom(x => new BaseEmployeeDto
            {
                Id = x.Employee.Id,
                Firstname = x.Employee.Firstname,
                Lastname = x.Employee.Lastname,
                Surname = x.Employee.Surname
            }))
            .ForMember(dto => dto.WorkMonth, opt => opt.MapFrom(x => new BaseWorkMonthDto
            {
                Date = x.WorkMonth.Date,
                Id = x.WorkMonth.Id
            }))
            .ForMember(dto => dto.WorkSchema, opt => opt.MapFrom(x => new BaseWorkSchemaDto
            {
                Id = x.WorkSchema.Id,
                StartTime = x.WorkSchema.StartTime,
                EndTime = x.WorkSchema.EndTime,
                Name = x.WorkSchema.Name,
                Schema = x.WorkSchema.Scheme
            }));
    }
}