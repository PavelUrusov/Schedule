namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses.EmployeeDtos;

public record GetListEmployeeDto : ResponseBase
{
    public IEnumerable<GetEmployeeDto> Employees { get; set; } = null!;
}