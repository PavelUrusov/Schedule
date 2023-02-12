using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

public record ResponseListWorkSchemaDto : ResponseBase, IMapWith<IEnumerable<WorkSchema>>
{
    public IEnumerable<BaseWorkSchemaDto> WorkSchemas { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IEnumerable<WorkSchema>, ResponseListWorkSchemaDto>()
            .ForMember(dto => dto.WorkSchemas, opt => opt.MapFrom(x => x));
    }
}