using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record ResponseGetEmployeeDto : ResponseBase, IMapWith<Employee>
{
    public BaseEmployeeDto Employee { get; init; } = null!;
    public int WorkObjectId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, ResponseGetEmployeeDto>()
            .ForMember(dto => dto.Employee, opt => opt.MapFrom(x => new BaseEmployeeDto
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Surname = x.Surname
            }))
            .ForMember(dto => dto.WorkObjectId, opt => opt.MapFrom(x => x.WorkObjectId));
    }
}