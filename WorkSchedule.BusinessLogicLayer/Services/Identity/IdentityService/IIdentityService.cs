using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Role;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Token;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.User;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RegisterUserDto registerDto);
    Task<ResponseBase> LoginAsync(LoginUserDto loginUserDto);
    Task<ResponseBase> RefreshAccessToken(TokenRequest token);
}