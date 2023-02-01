namespace WorkSchedule.BusinessLogicLayer.Services.Identity.PasswordEncryption;

public interface IPasswordEncryptionService
{
    string EncryptPassword(string password);
    byte[] ComputeHash(string password, byte[] salt);
}