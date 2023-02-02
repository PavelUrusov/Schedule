using System.Security.Cryptography;
using System.Text;

namespace WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordEncryption;

public class PasswordEncryptionService : IPasswordEncryptionService
{
    public virtual string EncryptPassword(string password)
    {
        var salt = GenerateSalt(16);
        var hash = ComputeHash(password, salt);
        var saltAndHash = salt.Concat(hash).ToArray();

        return Convert.ToBase64String(saltAndHash);
    }

    public virtual byte[] ComputeHash(string password, byte[] salt)
    {
        using var sha256 = SHA256.Create();
        var passwordAndSalt = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        var hash = sha256.ComputeHash(passwordAndSalt);

        return hash;
    }

    protected byte[] GenerateSalt(int size)
    {
        return RandomNumberGenerator.GetBytes(size);
    }
}