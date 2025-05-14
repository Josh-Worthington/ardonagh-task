using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;
using CustomerDetails.ViewModels.Activities;

namespace CustomerDetails.ViewModels;

/// <summary>
///     The main window view model.
/// </summary>
public sealed class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    /// <summary>
    ///     Constructor for the main window view model.
    /// </summary>
    /// <param name="customerService"> The customer service.</param>
    /// <param name="customerValidationService"> The customer validation service.</param>
    public MainWindowViewModel(ICustomerService customerService, ICustomerValidationService customerValidationService)
    {
        ActivityViewModel = new DefaultActivityViewModel(customerService, customerValidationService);
    }

    ViewModelBase? activityViewModel;
    /// <inheritdoc/>
    public ViewModelBase? ActivityViewModel
    {
        get => activityViewModel;
        set
        {
            activityViewModel = value;
            OnPropertyChanged();
        }
    }
}

