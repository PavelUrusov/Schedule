using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;

public interface IPasswordManager
{
    Result VerifyPassword(string password, string encryptedPassword);
}