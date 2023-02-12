using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

public record ResponseListWorkObjectDto : ResponseBase, IMapWith<IEnumerable<WorkObject>>
{
    public IEnumerable<BaseWorkObjectDto> WorkObjects { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IEnumerable<WorkObject>, ResponseListWorkObjectDto>()
            .ForMember(dto => dto.WorkObjects, opt => opt.MapFrom(x => x));
    }
}