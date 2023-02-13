namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.ScheduleDtos
{
    public record RequestGetRangeSchedulesDto
    {
        public int WorkObjectId { get; init; }
        public int WorkMonthId { get; init; }
    }
}