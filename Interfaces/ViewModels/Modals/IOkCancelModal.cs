using CustomerDetails.Interfaces.Input;

namespace CustomerDetails.Interfaces.ViewModels.Modals;

public interface IOkCancelModal
{
    /// <summary>
    ///     Gets the OK command.
    /// </summary>
    public IRelayCommand OkCommand { get; }

    /// <summary>
    ///     Gets the Cancel command.
    /// </summary>
    public IRelayCommand CancelCommand { get; }
}
