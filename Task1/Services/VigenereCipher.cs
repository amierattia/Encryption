using System.Text;

namespace Task1.Services
{
    public class VigenereCipher : IVigenereCipher
    {
        private char EncryptChar(char ch, char key)
        {
            if (!char.IsLetter(ch)) return ch;
            int offset = char.IsUpper(ch) ? 'A' : 'a';
            int shift = char.ToUpper(key) - 'A';
            return (char)((((ch - offset) + shift) % 26) + offset);
        }

        private char DecryptChar(char ch, char key)
        {
            if (!char.IsLetter(ch)) return ch;
            int offset = char.IsUpper(ch) ? 'A' : 'a';
            int shift = char.ToUpper(key) - 'A';
            return (char)((((ch - offset) - shift + 26) % 26) + offset);
        }

        public string Encrypt(string text, string key)
        {
            if (string.IsNullOrEmpty(key)) return text;
            StringBuilder result = new();
            int j = 0;
            foreach (char c in text)
            {
                result.Append(EncryptChar(c, key[j % key.Length]));
                if (char.IsLetter(c)) j++;
            }
            return result.ToString();
        }

        public string Decrypt(string cipherText, string key)
        {
            if (string.IsNullOrEmpty(key)) return cipherText;
            StringBuilder result = new();
            int j = 0;
            foreach (char c in cipherText)
            {
                result.Append(DecryptChar(c, key[j % key.Length]));
                if (char.IsLetter(c)) j++;
            }
            return result.ToString();
        }
    }
}
