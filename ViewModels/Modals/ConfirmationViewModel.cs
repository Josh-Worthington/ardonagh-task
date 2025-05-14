using System;
using CustomerDetails.Input;
using CustomerDetails.Interfaces.Input;
using CustomerDetails.Interfaces.ViewModels.Modals;
using MaterialDesignThemes.Wpf;

namespace CustomerDetails.ViewModels.Modals;

/// <summary>
///     The Are You Sure view model.
/// </summary>
public class ConfirmationViewModel : IOkCancelModal
{
    private readonly Action confirmationAction;

    /// <summary>
    ///     Default constructor.
    /// </summary>
    /// <param name="confirmationAction"> The action that gets executed when the user selects "OK". </param>
    /// <param name="confirmationAction"> The text that describes what happens when the user selects "OK". </param>
    public ConfirmationViewModel(Action confirmationAction, string descriptionText)
    {
        this.confirmationAction = confirmationAction ?? throw new ArgumentNullException(nameof(confirmationAction));
        DescriptionText = descriptionText ?? throw new ArgumentNullException(nameof(descriptionText));

        OkCommand = new RelayCommand(Confirm);
        CancelCommand = new RelayCommand(Cancel);
    }

    /// <summary>
    ///     Gets the text describing what happens on confirmation.
    /// </summary>
    public string DescriptionText { get; }

    /// <inheritdoc />
    public IRelayCommand OkCommand { get; }

    /// <inheritdoc />
    public IRelayCommand CancelCommand { get; }

    private void Confirm()
    {
        confirmationAction.Invoke();
        DialogHost.Close("RootDialog");
    }

    private void Cancel() => DialogHost.Close("RootDialog");
}
