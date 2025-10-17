namespace Task1.Services
{
    public interface IVigenereCipher
    {
        string Encrypt(string text, string key);
        string Decrypt(string cipherText, string key);
    }
}
