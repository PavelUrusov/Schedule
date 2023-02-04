using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.PasswordManager;

public interface IPasswordManager
{
    Result VerifyPassword(string password, string encryptedPassword);
}