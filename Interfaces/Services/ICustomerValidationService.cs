namespace CustomerDetails.Interfaces.Services;

/// <summary>
///     Interface for the customer validation service.
/// </summary>
public interface ICustomerValidationService
{
    /// <summary>
    ///     Validates the name to have less than 50 characters.
    /// </summary>
    string ValidateName(string name);

    /// <summary>
    ///     Validates the age to only contain numbers, with a minimum of 0 and maximum of 110.
    /// </summary>
    string ValidateAge(string age);

    /// <summary>
    ///     Validates the postcode to only contain alphanumeric characters.
    /// </summary>
    string ValidatePostcode(string postcode);

    /// <summary>
    ///     Validates the height to only contain numbers, with a minimum of 0 and maximum of 2.50 and two decimal places.
    /// </summary>
    string ValidateHeight(string height);
}
