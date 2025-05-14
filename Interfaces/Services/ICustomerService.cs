using System.Collections.ObjectModel;
using CustomerDetails.Interfaces.Entities;
using CustomerDetails.Interfaces.ViewModels;

namespace CustomerDetails.Interfaces.Services;

/// <summary>
///     The interface for customer service.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    ///     The collection of customers.
    /// </summary>
    ReadOnlyCollection<ICustomer> Customers { get; }

    /// <summary>
    ///     Adds a new customer to the list of customers.
    /// </summary>
    void AddCustomer(ICustomerViewModel newCustomer);

    /// <summary>
    ///     Edits a customer.
    /// </summary>
    void EditCustomer(ICustomerViewModel editCustomer);

    /// <summary>
    ///     Deletes the customer with the given id.
    /// </summary>
    void DeleteCustomer(int id);

    /// <summary>
    ///     Gets the customer with the given id.
    /// </summary>
    ICustomer GetCustomer(int id);
}
