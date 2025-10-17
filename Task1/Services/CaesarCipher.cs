using System.Collections.Generic;
using System.Text;

namespace Task1.Services
{
    public class CaesarCipher : ICaesarCipher
    {
        public string Encrypt(string? input, int shift)
        {
            return Transform(input, NormalizeShift(shift));
        }

        public string Decrypt(string? input, int shift)
        {
            return Transform(input, NormalizeShift(-shift));
        }

        public IEnumerable<(int Shift, string Candidate)> Crack(string? input)
        {
            if (string.IsNullOrEmpty(input))
                yield break;

            // try all shifts 0..25
            for (int s = 0; s < 26; s++)
            {
                yield return (s, Transform(input, NormalizeShift(-s))); // decrypt by shifting -s
            }
        }

        private static int NormalizeShift(int shift)
        {
            shift %= 26;
            if (shift < 0) shift += 26;
            return shift;
        }

        private static string Transform(string? input, int shift)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (var ch in input)
            {
                if (char.IsLetter(ch))
                {
                    bool isUpper = char.IsUpper(ch);
                    char baseChar = isUpper ? 'A' : 'a';
                    int offset = ch - baseChar;
                    int shifted = (offset + shift) % 26;
                    if (shifted < 0) shifted += 26;
                    char result = (char)(baseChar + shifted);
                    sb.Append(result);
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }
    }
}
