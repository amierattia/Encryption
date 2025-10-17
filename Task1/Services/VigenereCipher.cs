using System;

namespace Task1.Services
{
    /// <summary>
    /// Implements the Vigenère Cipher encryption system.
    /// Encrypts only alphabetic characters (A–Z or a–z).
    /// Non-letter characters (spaces, numbers, punctuation) remain unchanged.
    /// </summary>
    public class VigenereCipher : IVigenereCipher
    {
        private static string GenerateKey(string text, string key)
        {
            string onlyLetters = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                    onlyLetters += c;
            }

            int x = onlyLetters.Length;
            for (int i = 0; ; i++)
            {
                if (x == i)
                    i = 0;
                if (key.Length == onlyLetters.Length)
                    break;
                key += key[i];
            }
            return key;
        }

        private static string CipherText(string text, string key)
        {
            string cipherText = "";
            int j = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];

                if (!char.IsLetter(current))
                {
                    cipherText += current; 
                    continue;
                }

                int offset = char.IsUpper(current) ? 'A' : 'a';

                char keyChar = char.ToUpper(key[j % key.Length]);

                int shift = keyChar - 'A';
                char encryptedChar = (char)(((current - offset + shift) % 26) + offset);

                cipherText += encryptedChar;
                j++; 
            }

            return cipherText;
        }

        private static string OriginalText(string cipherText, string key)
        {
            string origText = "";
            int j = 0;

            for (int i = 0; i < cipherText.Length; i++)
            {
                char current = cipherText[i];

                if (!char.IsLetter(current))
                {
                    origText += current;
                    continue;
                }

                int offset = char.IsUpper(current) ? 'A' : 'a';
                char keyChar = char.ToUpper(key[j % key.Length]);
                int shift = keyChar - 'A';
                char decryptedChar = (char)(((current - offset - shift + 26) % 26) + offset);

                origText += decryptedChar;
                j++;
            }

            return origText;
        }

        public string Encrypt(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
                return text;

            string key = GenerateKey(text, keyword.ToUpper());
            return CipherText(text, key);
        }

        public string Decrypt(string cipherText, string keyword)
        {
            if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(keyword))
                return cipherText;

            string key = GenerateKey(cipherText, keyword.ToUpper());
            return OriginalText(cipherText, key);
        }
    }
}
