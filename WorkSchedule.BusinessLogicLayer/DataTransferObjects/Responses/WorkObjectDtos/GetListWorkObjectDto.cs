namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkObjectDtos;

public record WorkObjectsDtos : ResponseBase
{
    public IEnumerable<GetWorkObjectDto> Dtos { get; init; } = null!;
}