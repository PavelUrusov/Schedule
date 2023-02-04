using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Role;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.Token;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.User;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RegisterUserDto registerDto);
    Task<ResponseBase> LoginAsync(LoginUserDto loginUserDto);
    Task<ResponseBase> RefreshToken(TokenRequestDto token);
}