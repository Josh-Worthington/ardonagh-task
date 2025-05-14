using System.Collections.Generic;
using System.Linq;
using CustomerDetails.Entities;
using CustomerDetails.Interfaces.Entities;
using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;

namespace CustomerDetails.Services;

/// <summary>
///     An example class for DI.
/// </summary>
public class CustomerServiceSingleton : ICustomerService
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public CustomerServiceSingleton()
    {
        Customers = new List<ICustomer>();
    }

    /// <summary>
    ///     List of all the customers.
    /// </summary>
    public List<ICustomer> Customers { get; init; }

    /// <inheritdoc/>
    public void AddCustomer(ICustomerViewModel newCustomer)
    {
        Customers.Add(CreateCustomer(newCustomer));
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
    public void DeleteCustomer(int id) => Customers.Remove(GetCustomer(id));

    public ICustomer GetCustomer(int id) => Customers.SingleOrDefault(c => c.Id == id);

    private ICustomer CreateCustomer(ICustomerViewModel customerViewModel)
    {
        var customer = new Customer(customerViewModel.Id, customerViewModel.Name, int.Parse(customerViewModel.Age), customerViewModel.Postcode, double.Parse(customerViewModel.Height));
        return customer;
    }
}
