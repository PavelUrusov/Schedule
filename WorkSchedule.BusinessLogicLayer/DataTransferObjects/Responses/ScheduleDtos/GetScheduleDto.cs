using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkMonthDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkSchemaDtos;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.ScheduleDtos;

public record GetScheduleDto:ResponseBase,IMapWith<Schedule>
{
    public int Id { get; set; }
    public string ScheduleStart { get; set; } = null!;
    public GetWorkSchemaDto WorkSchema { get; set; } = null!;
    public GetWorkMonthDto WorkMonth { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Schedule,GetScheduleDto>()
            .ForMember(dto=>dto.Id,opt=>opt.MapFrom(x=>x.Id))
            .ForMember(dto => dto.ScheduleStart, opt => opt.MapFrom(x => x.ScheduleStart.ToString("dd.MM.yyyy")))
            .ForMember(dto => dto.WorkSchema, opt => opt.MapFrom(x => new GetWorkSchemaDto
            {
                Id = x.Id,

            }))
    }
}

/*
 *             .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dto => dto.StartTime, opt => opt.MapFrom(x => x.StartTime.ToString()))
            .ForMember(dto => dto.EndTime, opt => opt.MapFrom(x => x.StartTime.ToString()))
            .ForMember(dto => dto.Schema, opt => opt.MapFrom(x => x.Scheme));
 */