using System.Globalization;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The not empty validation rule.
/// </summary>
public class NotEmptyValidationRule : ValidationRule
{
    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        if (text.Length == 0)
        {
            return new ValidationResult(false, "Required.");
        }
        return ValidationResult.ValidResult;
    }
}
