namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.PasswordEncryption;

public interface IPasswordEncryptionService
{
    string EncryptPassword(string password);
    byte[] ComputeHash(string password, byte[] salt);
}