namespace Task1.Services
{
    public interface IRailFenceCipher
    {
        string Encrypt(string text, int rails);
        string Decrypt(string cipherText, int rails);
    }
}
