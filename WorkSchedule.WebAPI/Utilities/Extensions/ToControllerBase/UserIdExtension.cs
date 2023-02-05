using Microsoft.AspNetCore.Mvc;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.WebAPI.Utilities.Extensions.ToControllerBase;

public static class UserIdExtension
{
    public static int? UserId(this ControllerBase controllerBase)
    {
        var stringId = controllerBase.User.Claims.FirstOrDefault(x => x.Type == TypeUserClaims.Id)?.Value;

        return int.TryParse(stringId, out var id) ? id : null;
    }
}