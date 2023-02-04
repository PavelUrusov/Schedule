namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public record EmployeeDtos : ResponseBase
{
    public IEnumerable<EmployeeDto> Employees { get; init; } = null!;
}