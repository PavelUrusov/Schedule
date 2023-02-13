using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;

public record ResponseGetWorkMonthDto : ResponseBase, IMapWith<WorkMonth>
{
    public BaseWorkMonthDto WorkMonth { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<WorkMonth, ResponseGetWorkMonthDto>()
            .ForMember(dto => dto.WorkMonth, opt => opt.MapFrom(x => x));
    }
}