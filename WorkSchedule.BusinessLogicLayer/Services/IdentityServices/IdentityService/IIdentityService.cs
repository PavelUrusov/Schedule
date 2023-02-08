using WorkSchedule.BusinessLogicLayer.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.RoleDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.TokenDtos;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.UserDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RequestRegisterBaseUserDto requestRegisterBaseDto);
    Task<ResponseBase> LoginAsync(RequestLoginBaseUserDto requestLoginBaseUserDto);
    Task<ResponseBase> RefreshToken(RequestTokenDto requestToken);
}