namespace WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

public record TokenResponse(string AccessToken, string RefreshToken) : ResponseBase;