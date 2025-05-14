using CustomerDetails.Interfaces.Input;

namespace CustomerDetails.Interfaces.ViewModels.Activities;

/// <summary>
///     An example activity view model.
/// </summary>
public interface IDefaultActivityViewModel
{
    /// <summary>
    ///     An example command.
    /// </summary>
    IRelayCommand AddCustomerCommand { get; }

    /// <summary>
    ///     An example property.
    /// </summary>
    string ExampleProperty { get; }
}
