using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos;

public record ResponseGetEmployeeDto : ResponseBase, IMapWith<Employee>
{
    public BaseEmployeeDto Employee { get; init; } = null!;
    public int WorkObjectId { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, ResponseGetEmployeeDto>()
            .ForMember(dto=>dto.Employee,opt=>opt.MapFrom(x=>x))
            .ForMember(dto => dto.WorkObjectId, opt => opt.MapFrom(x => x.WorkObjectId));
    }
}