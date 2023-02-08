namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkObjectDto;

public record ResponseWorkObjectDto : ResponseBase
{
    public BaseWorkObjectDto WorkObject { get; init; } = null!;
}