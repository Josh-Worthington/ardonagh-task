using System.Globalization;
using System.Windows.Controls;

namespace CustomerDetails.ValidationRules;

/// <summary>
///     The number range validation rule.
/// </summary>
public class NumberRangeValidationRule : ValidationRule
{
    /// <summary>
    ///     The minimum allowed number.
    /// </summary>
    public double Min { get; set; }

    /// <summary>
    ///     The maximum allowed number.
    /// </summary>
    public double Max { get; set; }


    /// <inheritdoc/>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is not string text || double.TryParse(text, out double dValue))
        {
            return ValidationResult.ValidResult;
        }

        if (dValue > Max || dValue < Min)
        {
            return new ValidationResult(false, $"Must be between {Min} and {Max}.");
        }
        return ValidationResult.ValidResult;
    }
}
