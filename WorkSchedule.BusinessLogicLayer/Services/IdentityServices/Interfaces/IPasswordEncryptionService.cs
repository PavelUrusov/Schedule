namespace WorkSchedule.BusinessLogicLayer.Services.IdentityServices.Interfaces;

public interface IPasswordEncryptionService
{
    string EncryptPassword(string password);
    byte[] ComputeHash(string password, byte[] salt);
}