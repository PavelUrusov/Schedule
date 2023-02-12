using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkSchemaDtos;

public record RequestRemoveWorkSchemaDto
{
    [Required][Range(1, int.MaxValue)] public int Id { get; init; }
}