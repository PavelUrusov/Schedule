using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.WorkObjectDtos;

namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.EmployeeDtos;

public record RemoveEmployeeDto : EmployeeIdDto
{
    public WorkObjectIdDto WorkObjectIdDto { get; set; } = null!;
}

public record RemoveListEmployeeDto
{
    public IEnumerable<EmployeeIdDto> Employees { get; set; } = null!;
    public WorkObjectIdDto WorkObject { get; set; } = null!;
}