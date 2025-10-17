using System;
using System.Text;

namespace Task1.Services
{
    public class RailFenceCipher : IRailFenceCipher
    {
        public string Encrypt(string text, int rails)
        {
            if (rails <= 1) return text;

            var fence = new StringBuilder[rails];
            for (int i = 0; i < rails; i++)
                fence[i] = new StringBuilder();

            int dir = 1; // 1 = down, -1 = up
            int row = 0;
            foreach (char c in text)
            {
                fence[row].Append(c);
                if (row == 0) dir = 1;
                else if (row == rails - 1) dir = -1;
                row += dir;
            }

            var result = new StringBuilder();
            foreach (var sb in fence)
                result.Append(sb);
            return result.ToString();
        }

        public string Decrypt(string cipherText, int rails)
        {
            if (rails <= 1) return cipherText;

            // determine pattern
            bool down = false;
            int row = 0;
            var mark = new bool[rails, cipherText.Length];

            for (int i = 0; i < cipherText.Length; i++)
            {
                mark[row, i] = true;
                if (row == 0 || row == rails - 1)
                    down = !down;
                row += down ? 1 : -1;
            }

            // fill pattern
            int idx = 0;
            char[,] rail = new char[rails, cipherText.Length];
            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < cipherText.Length; j++)
                {
                    if (mark[i, j] && idx < cipherText.Length)
                        rail[i, j] = cipherText[idx++];
                }
            }

            // read zigzag
            string result = "";
            down = false; row = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                result += rail[row, i];
                if (row == 0 || row == rails - 1)
                    down = !down;
                row += down ? 1 : -1;
            }

            return result;
        }
    }
}
