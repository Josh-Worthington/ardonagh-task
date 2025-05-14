using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;

namespace CustomerDetails.ViewModels;

/// <summary>
///     The customer view model.
/// </summary>
public class CustomerViewModel(ICustomerValidationService customerValidationService, int id) : ViewModelBase, ICustomerViewModel
{
    /// <inheritdoc/>
    public int Id { get; } = id;

    /// <inheritdoc/>
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string Age { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string Postcode { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string Height { get; set; } = string.Empty;

    /// <inheritdoc/>
    public bool IsValid => Error.Length == 0;

    /// <inheritdoc/>
    public string this[string propertyName]
    {
        get
        {
            switch (propertyName)
            {
                case nameof(Name):
                    return customerValidationService.ValidateName(Name);
                case nameof(Age):
                    return customerValidationService.ValidateAge(Age);
                case nameof(Postcode):
                    return customerValidationService.ValidatePostcode(Postcode);
                case nameof(Height):
                    return customerValidationService.ValidateHeight(Height);
                default:
                    return string.Empty;
            }
        }
    }

    /// <inheritdoc/>
    public string Error => string.Empty;
}