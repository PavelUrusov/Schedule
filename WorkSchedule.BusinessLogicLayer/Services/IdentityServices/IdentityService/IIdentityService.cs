using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.RoleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.TokenDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Requests.UserDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RegisterUserDto registerDto);
    Task<ResponseBase> LoginAsync(LoginUserDto loginUserDto);
    Task<ResponseBase> RefreshToken(TokenRequestDto token);
}