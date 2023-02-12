using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.RoleDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.TokenDtos;
using WorkSchedule.BusinessLogicLayer.Shared.DataTransferObjects.UserDtos;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleDto roleDto);
    Task<ResponseBase> RegistrationAsync(RequestRegisterBaseUserDto requestRegisterBaseDto);
    Task<ResponseBase> LoginAsync(RequestLoginBaseUserDto requestLoginBaseUserDto);
    Task<ResponseBase> RefreshToken(RequestTokenDto requestToken);
}