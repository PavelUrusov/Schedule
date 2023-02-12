using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos;

public record BaseWorkMonthDto : IMapWith<WorkMonth>
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<WorkMonth, BaseWorkMonthDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
            .ForMember(dto => dto.Date, opt => opt.MapFrom(e => e.Date));
    }

}