using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record ResponseGetListEmployeeDto : ResponseBase, IMapWith<IEnumerable<Employee>>
{
    public IEnumerable<BaseEmployeeDto>? Employees { get; init; } = null!;
    public int? WorkObjectId { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IEnumerable<Employee>, ResponseGetListEmployeeDto>()
            .ForMember(dto => dto.WorkObjectId, opt => opt.MapFrom(x => x.First().WorkObjectId))
            .ForMember(dto => dto.Employees, opt => opt.MapFrom(x => x));
    }
}