using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CustomerDetails.Entities;
using CustomerDetails.Interfaces.Entities;
using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;

namespace CustomerDetails.Services;

/// <summary>
///     The customer service singleton.
/// </summary>
public class CustomerServiceSingleton : ICustomerService
{
    private readonly List<ICustomer> customers;
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public CustomerServiceSingleton()
    {
        customers = [];
        Customers = new ReadOnlyCollection<ICustomer>(customers);
    }

    /// <summary>
    ///     List of all the customers.
    /// </summary>
    public ReadOnlyCollection<ICustomer> Customers { get; init; }

    /// <inheritdoc/>
    public void AddCustomer(ICustomerViewModel newCustomer)
    {
        customers.Add(CreateCustomer(newCustomer));
    }

    /// <inheritdoc/>
    public void EditCustomer(ICustomerViewModel editCustomer)
    {
        var customer = GetCustomer(editCustomer.Id);
        customer.Name = editCustomer.Name;
        customer.Age = int.Parse(editCustomer.Age);
        customer.Postcode = editCustomer.Postcode;
        customer.Height = double.Parse(editCustomer.Height);
    }

    /// <inheritdoc/>
    public void DeleteCustomer(int id) => customers.Remove(GetCustomer(id));

    /// <inheritdoc/>
    public ICustomer GetCustomer(int id) => customers.SingleOrDefault(c => c.Id == id);

    private ICustomer CreateCustomer(ICustomerViewModel customerViewModel)
    {
        var customer = new Customer(customerViewModel.Id, customerViewModel.Name, int.Parse(customerViewModel.Age), customerViewModel.Postcode, double.Parse(customerViewModel.Height));
        return customer;
    }
}
