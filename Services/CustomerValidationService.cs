using System.Collections.Generic;
using System.Text.RegularExpressions;
using CustomerDetails.Enums;
using CustomerDetails.Interfaces.Services;

namespace CustomerDetails.Services;

/// <summary>
///     The customer validation service.
/// </summary>
public class CustomerValidationService : ICustomerValidationService
{
    private readonly static Dictionary<Validation, string> ValidationErrorMessages = new Dictionary<Validation, string>
    {
        { Validation.Valid, string.Empty },
        { Validation.TooManyCharacters, "Must be less than {0} characters." },
        { Validation.OutOfBounds, "Must be between {0} and {1}." },
        { Validation.InvalidCharactersAlphanumeric, "Must only contain alphanumeric characters." },
        { Validation.InvalidCharactersLetters, "Must only contain letters." },
        { Validation.InvalidCharactersNumber, "Must only contain digits." },
        { Validation.InvalidCharactersDecimal, "Must only contain digits with at most two decimal places." }
    };

    /// <inheritdoc/>
    public string ValidateName(string name)
    {
        var regex = new Regex("^[A-Za-z\\s]+$");
        if (!regex.IsMatch(name))
        {
            return ValidationErrorMessages[Validation.InvalidCharactersLetters];
        }
        if (name.Length > 50)
        {
            return string.Format(ValidationErrorMessages[Validation.TooManyCharacters], 50);
        }
        return string.Empty;
    }

    /// <inheritdoc/>
    public string ValidateAge(string age)
    {
        var regex = new Regex("^[0-9]+$");
        if (!regex.IsMatch(age))
        {
            return ValidationErrorMessages[Validation.InvalidCharactersNumber];
        }

        var valid = int.TryParse(age, out var iAge);
        if (!valid)
        {
            return "(DEV ERROR) Input is not a valid double.";
        }

        if (iAge > 110 || iAge < 0)
        {
            return string.Format(ValidationErrorMessages[Validation.OutOfBounds], 0, 110);
        }
        return string.Empty;
    }

    /// <inheritdoc/>
    public string ValidatePostcode(string postcode)
    {
        var regex = new Regex("^[a-zA-Z0-9\\s]+$");
        if (!regex.IsMatch(postcode))
        {
            return ValidationErrorMessages[Validation.InvalidCharactersAlphanumeric];
        }
        return string.Empty;
    }

    /// <inheritdoc/>
    public string ValidateHeight(string height)
    {
        var regex = new Regex("^(\\d+)+.?(\\d)?(\\d)?$");
        if (!regex.IsMatch(height))
        {
            return ValidationErrorMessages[Validation.InvalidCharactersDecimal];
        }

        var valid = double.TryParse(height, out var dHeight);
        if (!valid)
        {
            return "(DEV ERROR) Input is not a valid integer.";
        }

        if (dHeight > 2.5 || dHeight < 0)
        {
            return string.Format(ValidationErrorMessages[Validation.OutOfBounds], 0, 2.5);
        }
        return string.Empty;
    }
}
