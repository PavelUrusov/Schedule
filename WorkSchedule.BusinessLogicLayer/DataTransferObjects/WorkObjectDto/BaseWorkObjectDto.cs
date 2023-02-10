using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkMothDtos;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

public record BaseWorkObjectDto : IMapWith<WorkObject>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public IEnumerable<BaseWorkMonthDto> WorkMonths { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<WorkObject, BaseWorkObjectDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dto => dto.WorkMonths,
                opt => opt.MapFrom(x =>
                    x.WorkMonths.Select(wo => new BaseWorkMonthDto { Date = wo.Date, Id = wo.Id })));
    }
}