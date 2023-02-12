using AutoMapper;
using WorkSchedule.BusinessLogicLayer.Shared.Mappings;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkObjectDto;

public record ResponseWorkObjectDto : ResponseBase, IMapWith<WorkObject>
{
    public BaseWorkObjectDto WorkObject { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<WorkObject, ResponseWorkObjectDto>();
    }
}