using WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;
using WorkSchedule.BusinessLogicLayer.Shared;

namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Implementation;

public class PasswordManager : IPasswordManager
{
    private readonly IPasswordEncryptionService _passwordEncryption;

    public PasswordManager(IPasswordEncryptionService passwordEncryption)
    {
        _passwordEncryption = passwordEncryption;
    }

    public virtual Result VerifyPassword(string password, string encryptedPassword)
    {
        var computedHash = ComputePasswordHash(password, encryptedPassword);

        return ComparePasswordHash(encryptedPassword, computedHash);
    }

    protected byte[] ComputePasswordHash(string password, string encryptedPassword)
    {
        var result = Convert.FromBase64String(encryptedPassword);
        var salt = result.Take(16).ToArray();

        return _passwordEncryption.ComputeHash(password, salt);
    }

    protected Result ComparePasswordHash(string encryptedPassword, byte[] computedHash)
    {
        var storedHash = Convert.FromBase64String(encryptedPassword)
            .Skip(16)
            .ToArray();

        return storedHash.SequenceEqual(computedHash) is false
            ? new Result("Password not verified")
            : new Result();
    }
}