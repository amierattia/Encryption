using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task1.Validation; 

namespace Task1.Models
{
    public class CaesarViewModel
    {
        [Display(Name = "Mode")]
        [Required]
        public string Mode { get; set; } = "Encrypt"; 

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please enter some text.")]
        [MinLength(1, ErrorMessage = "Please enter some text.")]
        [NoArabic(ErrorMessage = "Arabic letters are not allowed.")] 
        public string Text { get; set; } = string.Empty;

        // Accept ANY integer key from user
        [Display(Name = "Key (any integer)")]
        public int RawKey { get; set; } = 3;

        [Display(Name = "Effective Key (0 - 25)")]
        public int EffectiveKey { get; set; } = 3;

        [Display(Name = "Result")]
        public string? Result { get; set; }

        // for crack results
        public List<CrackCandidate>? Candidates { get; set; }
    }

    public class CrackCandidate
    {
        public int Shift { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
