namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.WorkSchemaDtos;

public record ResponseListWorkSchemaDto : ResponseBase
{
    public IEnumerable<BaseWorkSchemaDto> WorkSchemas { get; init; } = null!;
}