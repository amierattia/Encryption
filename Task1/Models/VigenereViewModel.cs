using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class VigenereViewModel
    {
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Key (letters only)")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Key must contain only letters.")]
        public string Key { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mode")]
        public string Mode { get; set; } = "Encrypt";

        [Display(Name = "Result")]
        public string? Result { get; set; }
    }
}
