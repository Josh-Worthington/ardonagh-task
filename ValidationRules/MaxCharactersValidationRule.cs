using System.Globalization;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The max characters validation rule.
/// </summary>
public class MaxCharactersValidationRule : ValidationRule
{
    public int MaxCharacters { get; set; }

    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        if (text.Length > MaxCharacters)
        {
            return new ValidationResult(false, $"Must be less than {MaxCharacters} characters.");
        }
        return ValidationResult.ValidResult;
    }
}
