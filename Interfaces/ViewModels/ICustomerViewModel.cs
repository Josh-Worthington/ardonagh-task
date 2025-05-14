using System.ComponentModel;

namespace CustomerDetails.Interfaces.ViewModels;

public interface ICustomerViewModel : IDataErrorInfo
{
    /// <summary>
    ///     Gets the customer id.
    /// </summary>
    int Id { get; }

    /// <summary>
    ///     Gets or sets the customer name.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    ///     Gets or sets the customer age.
    /// </summary>
    string Age { get; set; }

    /// <summary>
    ///     Gets or sets the customer postcode.
    /// </summary>
    string Postcode { get; set; }

    /// <summary>
    ///     Gets or sets the customer height.
    /// </summary>
    string Height { get; set; }

    /// <summary>
    ///     Gets or sets if the customer details are valid.
    /// </summary>
    bool IsValid { get; }
}
