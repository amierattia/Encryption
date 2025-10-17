using System.Collections.Generic;

namespace Task1.Services
{
    // Note: using tuples to return crack candidates
    public interface ICaesarCipher
    {
        string Encrypt(string? input, int shift);
        string Decrypt(string? input, int shift);

        // Return all 26 candidates as (shift, candidateText)
        IEnumerable<(int Shift, string Candidate)> Crack(string? input);
    }
}
