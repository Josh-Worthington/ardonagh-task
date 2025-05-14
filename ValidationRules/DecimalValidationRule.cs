using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The decimal validation rule.
/// </summary>
public class DecimalValidationRule : ValidationRule
{
    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        var regex = new Regex("/^(\\d+)+.?(\\d)?$");
        if (!regex.IsMatch(text))
        {
            return new ValidationResult(false, "Must only contain numeric characters and a single decimal point.");
        }
        return ValidationResult.ValidResult;
    }
}
