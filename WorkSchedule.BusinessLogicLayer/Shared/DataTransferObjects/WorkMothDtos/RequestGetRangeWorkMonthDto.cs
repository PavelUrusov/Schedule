namespace WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.WorkMothDtos
{
    public record RequestGetRangeWorkMonthDto
    {
        public int WorkObjectId { get; init; }
    }
}