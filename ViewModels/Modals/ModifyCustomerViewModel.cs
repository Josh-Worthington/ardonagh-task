using CustomerDetails.Input;
using CustomerDetails.Interfaces.Input;
using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;
using CustomerDetails.Interfaces.ViewModels.Modals;
using MaterialDesignThemes.Wpf;

namespace CustomerDetails.ViewModels.Modals;

/// <summary>
///     Add customer view model.
/// </summary>
public class ModifyCustomerViewModel : IModifyCustomerViewModel
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public ModifyCustomerViewModel(ICustomerValidationService customerValidationService, int id)
    {
        Customer = new CustomerViewModel(customerValidationService, id);

        OkCommand = new RelayCommand(() => Close(false));
        CancelCommand = new RelayCommand(() => Close(true));
    }

    /// <inheritdoc/>
    public ICustomerViewModel Customer { get; set; }

    /// <inheritdoc/>
    public IRelayCommand OkCommand { get; init; }

    /// <inheritdoc/>
    public IRelayCommand CancelCommand { get; init; }

    public bool IsValid => Customer.IsValid;

    private void Close(bool cancel)
    {
        if (cancel)
        {
            DialogHost.Close("RootDialog", null);
        }
        else
        {
            DialogHost.Close("RootDialog", Customer);
        }
    }
}
