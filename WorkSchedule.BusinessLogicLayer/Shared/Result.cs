namespace WorkSchedule.BusinessLogicLayer.Shared;

public record Result
{
    public Result()
    {
        IsSuccessful = true;
    }

    public Result(string? errorMessage)
    {
        IsSuccessful = false;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccessful { get; init; }
    public string? ErrorMessage { get; init; }
    public bool IsUnsuccessful => !IsSuccessful;
}

public record Result<T> : Result
{
    public Result(string? errorMessage) : base(errorMessage)
    {
    }

    public Result(T data)
    {
        IsSuccessful = true;
        Data = data;
    }

    public T? Data { get; init; }
}