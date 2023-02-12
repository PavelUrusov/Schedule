using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;
using WorkSchedule.DataAccessLayer.Entities.Enums;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

public record BaseWorkSchemaDto : IMapWith<WorkSchema>
{
    public int Id { get; set; }
    public string Name { get; init; } = null!;
    public DayType[] Schema { get; init; } = null!;
    public string StartTime { get; init; } = null!;
    public string EndTime { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<WorkSchema, BaseWorkSchemaDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(ws => ws.Id))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(ws => ws.Name))
            .ForMember(dto => dto.Schema, opt => opt.MapFrom(ws => ws.Scheme))
            .ForMember(dto => dto.StartTime, opt => opt.MapFrom(ws => ws.StartTime))
            .ForMember(dto => dto.EndTime, opt => opt.MapFrom(ws => ws.EndTime));
    }
}