using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkSchemaDtos;

public class GetWorkSchemaDto : IMapWith<WorkSchema>
{
    public int Id { get; set; }
    public string Name { get; init; } = null!;
    public DayType[] Schema { get; init; } = null!;
    public string StartTime { get; init; } = null!;
    public string EndTime { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<WorkSchema, GetWorkSchemaDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dto => dto.StartTime, opt => opt.MapFrom(x => x.StartTime.ToString()))
            .ForMember(dto => dto.EndTime, opt => opt.MapFrom(x => x.StartTime.ToString()))
            .ForMember(dto => dto.Schema, opt => opt.MapFrom(x => x.Scheme));
    }
}