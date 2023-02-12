namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.EmployeeDtos
{
    public record RequestGetListEmployeeDto
    {
        public int WorkObjectId { get; init; }
    }
}