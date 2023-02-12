using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos;

public record ResponseGetScheduleDto : ResponseBase, IMapWith<Schedule>
{
    public BaseScheduleDto Schedule { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Schedule, ResponseGetScheduleDto>();
    }
}