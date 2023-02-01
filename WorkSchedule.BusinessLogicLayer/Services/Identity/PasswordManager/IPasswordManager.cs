using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordManager;

public interface IPasswordManager
{
    Result VerifyPassword(string password, string encryptedPassword);
}