using AutoMapper;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkMonthDtos;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkObjectDtos;

public record GetWorkObjectDto : ResponseBase, IMapWith<WorkObject>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public IEnumerable<GetWorkMonthDto> WorkMonths { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<WorkObject, GetWorkObjectDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dto => dto.WorkMonths,
                opt => opt.MapFrom(x => x.WorkMonths.Select(wm => new GetWorkMonthDto
                {
                    Id = wm.Id, Date = wm.Date.ToString("MM.yyyy")
                })));
    }
}

