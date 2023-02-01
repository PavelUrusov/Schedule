namespace WorkSchedule.BusinessLogicLayer.Shared
{
    public static class ErrorMessageBuilder
    {
        public static string? RequiredError(string propertyName)
        {
            return $"The {propertyName} property is required";
        }
    }

}
