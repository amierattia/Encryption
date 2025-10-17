using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task1.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NoArabicAttribute : ValidationAttribute
    {
        private static readonly Regex ArabicRegex = new Regex(
            @"[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDFF\uFE70-\uFEFF]",
            RegexOptions.Compiled);

        public override bool IsValid(object? value)
        {
            if (value == null) return true; 
            var s = value.ToString();
            if (string.IsNullOrEmpty(s)) return true;
            return !ArabicRegex.IsMatch(s);
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? $"{name} must not contain Arabic characters.";
        }
    }
}
