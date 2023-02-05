using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.PasswordEncryption;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.PasswordManager;

public class PasswordManager : IPasswordManager
{
    private readonly IPasswordEncryptionService _passwordEncryption;

    public PasswordManager(IPasswordEncryptionService passwordEncryption)
    {
        _passwordEncryption = passwordEncryption;
    }

    public virtual Result VerifyPassword(string password, string encryptedPassword)
    {
        var result = Convert.FromBase64String(encryptedPassword);
        var salt = result.Take(16).ToArray();
        var storedHash = result.Skip(16).ToArray();
        var computedHash = _passwordEncryption.ComputeHash(password, salt);

        return storedHash.SequenceEqual(computedHash) is false
            ? new Result("Password not verified")
            : new Result();
    }
}