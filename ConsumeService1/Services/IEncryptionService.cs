public interface IEncryptionService
{
    Task<string> DecryptDataAsync(string encryptedText, string key);
    Task<string> EncryptDataAsync(string encryptedText, string key);
}