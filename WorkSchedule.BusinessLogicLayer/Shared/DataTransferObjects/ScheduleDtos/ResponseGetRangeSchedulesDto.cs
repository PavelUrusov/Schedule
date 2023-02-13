using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

public record ResponseGetRangeSchedulesDto : ResponseBase, IMapWith<IEnumerable<Schedule>>
{
    public IEnumerable<BaseScheduleDto> Schedules { get; init; } = null!;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<IEnumerable<Schedule>, ResponseGetRangeSchedulesDto>()
            .ForMember(dto => dto.Schedules, opt => opt.MapFrom(x => x));
    }
}