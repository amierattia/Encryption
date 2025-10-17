using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class RailFenceViewModel
    {
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; } = string.Empty;

        [Required]
        [Range(2, 10, ErrorMessage = "Rails must be between 2 and 10")]
        [Display(Name = "Number of Rails")]
        public int Rails { get; set; } = 3;

        [Required]
        [Display(Name = "Mode")]
        public string Mode { get; set; } = "Encrypt"; // or Decrypt

        [Display(Name = "Result")]
        public string? Result { get; set; }
    }
}
