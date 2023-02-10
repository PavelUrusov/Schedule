namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.EmployeeDtos;

public record BaseEmployeeDto
{
    public int Id { get; init; }
    public string Firstname { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string? Lastname { get; init; }
}