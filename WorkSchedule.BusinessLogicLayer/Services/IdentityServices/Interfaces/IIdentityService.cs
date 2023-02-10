using WorkSchedule.BusinessLogicLayer.DataTransferObjects.RoleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.TokenDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.UserDtos;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RequestRegisterBaseUserDto requestRegisterBaseDto);
    Task<ResponseBase> LoginAsync(RequestLoginBaseUserDto requestLoginBaseUserDto);
    Task<ResponseBase> RefreshToken(RequestTokenDto requestToken);
}