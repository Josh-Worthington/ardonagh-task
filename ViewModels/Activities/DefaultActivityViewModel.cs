using System;
using System.Collections.ObjectModel;
using System.Linq;
using CustomerDetails.Input;
using CustomerDetails.Interfaces.Entities;
using CustomerDetails.Interfaces.Input;
using CustomerDetails.Interfaces.Services;
using CustomerDetails.Interfaces.ViewModels;
using CustomerDetails.Interfaces.ViewModels.Activities;
using CustomerDetails.ViewModels.Modals;
using MaterialDesignThemes.Wpf;

namespace CustomerDetails.ViewModels.Activities;

/// <summary>
///     The default activity view model.
/// </summary>
public sealed class DefaultActivityViewModel : ViewModelBase, IDefaultActivityViewModel
{
    private readonly ICustomerService customerService;
    private readonly ICustomerValidationService customerValidationService;

    /// <summary>
    ///     Constructor for the default activity view model.
    /// </summary>
    /// <param name="customerService"></param>
    public DefaultActivityViewModel(ICustomerService customerService, ICustomerValidationService customerValidationService)
    {
        this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        this.customerValidationService = customerValidationService ?? throw new ArgumentNullException(nameof(customerValidationService));

        AddCustomerCommand = new RelayCommand(OpenAddCustomerModal);
        EditCustomerCommand = new RelayCommand(OpenEditCustomerModal);
    }

    /// <inheritdoc/>
    public IRelayCommand AddCustomerCommand { get; init; }

    /// <inheritdoc/>
    public IRelayCommand EditCustomerCommand { get; init; }

    public bool CanEditCustomer => Customers.Count > 0 && SelectedCustomerId > -1;

    /// <inheritdoc/>
    public string ExampleProperty => "Example";

    public ObservableCollection<ICustomer> Customers => new(customerService.Customers);

    private int _selectedCustomerId = -1;
    public int SelectedCustomerId
    {
        get => _selectedCustomerId;
        set
        {
            _selectedCustomerId = value;
            OnPropertyChanged(nameof(CanEditCustomer));
        }
    }

    public async void OpenAddCustomerModal()
    {
        var nextId = Customers.Count > 0 ? Customers.Max(c => c.Id) + 1 : 0;

        var addCustomerViewModel = new ModifyCustomerViewModel(customerValidationService, nextId);

        var result = await DialogHost.Show(addCustomerViewModel, "RootDialog");

        if (result is ICustomerViewModel customerViewModel)
        {
            customerService.AddCustomer(customerViewModel);
        }

        OnPropertyChanged(nameof(Customers));
        OnPropertyChanged(nameof(CanEditCustomer));
    }

    public async void OpenEditCustomerModal()
    {
        var customer = customerService.GetCustomer(SelectedCustomerId);
        var editCustomerViewModel = new ModifyCustomerViewModel(customerValidationService, SelectedCustomerId);
        editCustomerViewModel.Customer.Name = customer.Name;
        editCustomerViewModel.Customer.Age = customer.Age.ToString();
        editCustomerViewModel.Customer.Postcode = customer.Postcode;
        editCustomerViewModel.Customer.Height = customer.Height.ToString();

        var result = await DialogHost.Show(editCustomerViewModel, "RootDialog");

        if (result is ICustomerViewModel customerViewModel)
        {
            customerService.EditCustomer(customerViewModel);
        }

        OnPropertyChanged(nameof(Customers));
    }
}
