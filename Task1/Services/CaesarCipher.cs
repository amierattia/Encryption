using System.Collections.Generic;
using System.Linq;

namespace Task1.Services
{
    /// <summary>
    /// Implements a Caesar Cipher encryption system.
    /// Provides methods to encrypt, decrypt, and crack ciphered text.
    /// 
    /// Encrypt: Shifts letters forward by the specified amount.
    /// Decrypt: Shifts letters backward using (26 - key).
    /// Crack: Tries all 26 possible shifts to find potential plaintexts.
    /// 
    /// The Cipher method handles shifting individual characters.
    /// Keeps non-letter characters unchanged.
    /// </summary>
    public class CaesarCipher : ICaesarCipher
    {
        public string Encrypt(string? input, int key) => Encipher(input, key);
        public string Decrypt(string? input, int key) => Encipher(input, 26 - key);

        public IEnumerable<(int Shift, string Candidate)> Crack(string? input) =>
            string.IsNullOrEmpty(input)
                ? Enumerable.Empty<(int, string)>()
                : Enumerable.Range(0, 26).Select(s => (s, Encipher(input, s)));

        private static string Encipher(string? message, int key)
        {
            if (string.IsNullOrEmpty(message)) return string.Empty;
            return new string(message.Select(ch => Cipher(ch, key)).ToArray());
        }

        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch)) return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }
    }
}
