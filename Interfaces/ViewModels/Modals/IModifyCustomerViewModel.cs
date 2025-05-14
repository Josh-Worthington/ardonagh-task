namespace CustomerDetails.Interfaces.ViewModels.Modals;

/// <summary>
///     Interface for the add customer view model.
/// </summary>
public interface IModifyCustomerViewModel : IOkCancelModal
{
    /// <summary>
    ///     Gets or sets the customer view model.
    /// </summary>
    ICustomerViewModel Customer { get; set; }
}
