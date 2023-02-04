using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public record EmployeeDto : ResponseBase,IMapWith<Employee>
{
    public int Id { get; set; }
    public IEnumerable<ScheduleDto> Schedules { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Lastname { get; set; }

    public void Mapping(Profile profile)
    {
        var t = new Employee();
        var g = t.Schedules.Select(x => new ScheduleDto { Scheme = x.WorkSchema.Scheme, Id = x.Id });
        profile.CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
            .ForMember(dto => dto.Firstname, opt => opt.MapFrom(e => e.Firstname))
            .ForMember(dto => dto.Surname, opt => opt.MapFrom(e => e.Surname))
            .ForMember(dto => dto.Lastname, opt => opt.MapFrom(e => e.Surname))
            .ForMember(dto => dto.Schedules, opt => opt.MapFrom(e => e.Schedules.Select(x => new ScheduleDto{Scheme = x.WorkSchema.Scheme,Id = x.Id})));
    }
}