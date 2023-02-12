using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record BaseEmployeeDto : IMapWith<Employee>
{
    public int Id { get; init; }
    public string Firstname { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string? Lastname { get; init; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, BaseEmployeeDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
            .ForMember(dto => dto.Firstname, opt => opt.MapFrom(e => e.Firstname))
            .ForMember(dto => dto.Surname, opt => opt.MapFrom(e => e.Surname))
            .ForMember(dto => dto.Lastname, opt => opt.MapFrom(e => e.Lastname));
    }

}