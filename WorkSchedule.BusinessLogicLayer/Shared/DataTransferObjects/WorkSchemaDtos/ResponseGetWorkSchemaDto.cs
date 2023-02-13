using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

public record ResponseGetWorkSchemaDto : ResponseBase, IMapWith<WorkSchema>
{
    public BaseWorkSchemaDto WorkSchema { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<WorkSchema, ResponseGetWorkSchemaDto>();
    }
}