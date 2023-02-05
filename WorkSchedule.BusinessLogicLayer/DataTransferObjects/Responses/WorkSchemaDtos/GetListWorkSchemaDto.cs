namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.WorkSchemaDtos;

public record GetListWorkSchemaDto : ResponseBase
{
    public IEnumerable<GetWorkSchemaDto> Dtos { get; init; } = null!;
}