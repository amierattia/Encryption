using System;

namespace Task1.Services
{
    /// <summary>
    /// Implements the Vigenère Cipher encryption system.
    /// Uses a repeating keyword to determine character shifts.
    /// 
    /// Encrypt: Combines each letter of the text with a corresponding letter from the key.
    /// Decrypt: Reverses the process to restore the original message.
    /// 
    /// The generateKey method repeats the key to match text length.
    /// The cipherText and originalText methods handle encryption and decryption.
    /// </summary>
    public class VigenereCipher : IVigenereCipher
    {
        private static string GenerateKey(string text, string key)
        {
            int x = text.Length;
            for (int i = 0; ; i++)
            {
                if (x == i)
                    i = 0;
                if (key.Length == text.Length)
                    break;
                key += key[i];
            }
            return key;
        }

        private static string CipherText(string text, string key)
        {
            string cipherText = "";
            for (int i = 0; i < text.Length; i++)
            {
                int x = (text[i] + key[i]) % 26;
                x += 'A';
                cipherText += (char)x;
            }
            return cipherText;
        }

        private static string OriginalText(string cipherText, string key)
        {
            string origText = "";
            for (int i = 0; i < cipherText.Length && i < key.Length; i++)
            {
                int x = (cipherText[i] - key[i] + 26) % 26;
                x += 'A';
                origText += (char)x;
            }
            return origText;
        }

        public string Encrypt(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
                return text;

            text = text.ToUpper();
            keyword = keyword.ToUpper();

            string key = GenerateKey(text, keyword);
            return CipherText(text, key);
        }

        public string Decrypt(string cipherText, string keyword)
        {
            if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(keyword))
                return cipherText;

            cipherText = cipherText.ToUpper();
            keyword = keyword.ToUpper();

            string key = GenerateKey(cipherText, keyword);
            return OriginalText(cipherText, key);
        }
    }
}
