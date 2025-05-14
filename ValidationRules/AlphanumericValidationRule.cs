using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The alphanumeric validation rule.
/// </summary>
public class AlphanumericValidationRule : ValidationRule
{
    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        var regex = new Regex("/[a-zA-Z0-9]/gu");
        if (!regex.IsMatch(text))
        {
            return new ValidationResult(false, "Must only contain alphanumeric characters.");
        }
        return ValidationResult.ValidResult;
    }
}
