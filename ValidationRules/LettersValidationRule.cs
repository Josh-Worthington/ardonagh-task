using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The name validation rule.
/// </summary>
public class LettersValidationRule : ValidationRule
{
    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        // Matches if any characters are not letters or a space
        var regex = new Regex("[^a-zA-Z\\s]+");
        if (regex.IsMatch(text))
        {
            return new ValidationResult(false, "Must only contain letters.");
        }
        return ValidationResult.ValidResult;
    }
}
