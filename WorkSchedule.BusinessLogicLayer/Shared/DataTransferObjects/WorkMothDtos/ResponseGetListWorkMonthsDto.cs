using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;

public record ResponseGetListWorkMonthsDto : ResponseBase, IMapWith<IEnumerable<WorkMonth>>
{
    public IEnumerable<BaseWorkMonthDto> WorkMonths { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<IEnumerable<WorkMonth>, ResponseGetListWorkMonthsDto>()
            .ForMember(dto => dto.WorkMonths, opt => opt.MapFrom(x => x));
    }
}