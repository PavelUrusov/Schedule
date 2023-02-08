namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

public record ResponseListWorkObjectDto : ResponseBase
{
    public IEnumerable<BaseWorkObjectDto> WorkObjects { get; init; } = null!;
}