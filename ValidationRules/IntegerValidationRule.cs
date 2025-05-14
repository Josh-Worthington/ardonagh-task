using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The integer validation rule.
/// </summary>
public class IntegerValidationRule : ValidationRule
{
    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text)
        {
            return ValidationResult.ValidResult;
        }

        var regex = new Regex("/[0-9]/gu");
        if (!regex.IsMatch(text))
        {
            return new ValidationResult(false, "Must only contain numeric characters.");
        }
        return ValidationResult.ValidResult;
    }
}
