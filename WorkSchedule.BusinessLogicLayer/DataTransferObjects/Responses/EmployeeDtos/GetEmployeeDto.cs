using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.ScheduleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkMonthDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.EmployeeDtos;

public record GetEmployeeDto : ResponseBase, IMapWith<Employee>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Lastname { get; set; }
    public GetScheduleDto Schedule { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, GetEmployeeDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(x => x.Firstname))
            .ForMember(dto => dto.Surname, opt => opt.MapFrom(x => x.Surname))
            .ForMember(dto => dto.Lastname, opt => opt.MapFrom(x => x.Lastname))
            .ForMember(dto => dto.Schedule, opt => opt.Ignore());

    }
}