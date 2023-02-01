using System.Security.Claims;

namespace WorkSchedule.BusinessLogicLayer.Shared;

public static class TypeUserClaims
{
    public static string Email => ClaimTypes.Email;
    public static string Id => "userId";
    public static string Username => ClaimTypes.Name;
    public static string Role => ClaimTypes.Role;
}