using System.Collections.Generic;
using System.Linq;
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
    public bool IsValid => !Errors.Values.Any(s => s.Length > 0);

    /// <inheritdoc/>
    public string this[string propertyName]
    {
        get
        {
            var error = propertyName switch
            {
                nameof(Name) => customerValidationService.ValidateName(Name),
                nameof(Age) => customerValidationService.ValidateAge(Age),
                nameof(Postcode) => customerValidationService.ValidatePostcode(Postcode),
                nameof(Height) => customerValidationService.ValidateHeight(Height),
                _ => string.Empty,
            };
            Errors[propertyName] = error;
            OnPropertyChanged(nameof(IsValid));
            return error;
        }
    }

    /// <inheritdoc/>
    public string Error => string.Empty;

    /// <summary>
    ///     Keeps track of the current validation errors.
    /// </summary>
    public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>
    {
        { nameof(Name), string.Empty },
        { nameof(Age), string.Empty },
        { nameof(Postcode), string.Empty },
        { nameof(Height), string.Empty }
    };
}