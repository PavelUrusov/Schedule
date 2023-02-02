using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Responses;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Role;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.Token;
using WorkSchedule.BusinessLogicLayer.DataTransferObjects.User;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.IdentityService;

public interface IIdentityService
{
    Task<ResponseBase> AddRoleAsync(AddRoleRequest roleRequest);
    Task<ResponseBase> RegistrationAsync(RegisterUserRequest registerRequest);
    Task<ResponseBase> LoginAsync(LoginUserRequest loginUserRequest);
    Task<ResponseBase> RefreshToken(TokenRequest token);
}