namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkObject;

public record WorkObjectDto : ResponseBase
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
}

public record WorkObjectsDtos : ResponseBase
{
    public IEnumerable<WorkObjectDto> Dtos { get; init; } = null!;
}