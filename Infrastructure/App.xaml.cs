using System.Windows;
using CustomerDetails.Interfaces.Services;
using CustomerDetails.ViewModels;
using CustomerDetails.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerDetails.Infrastructure;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var bootstrapper = new Bootstrapper();
        bootstrapper.Start();

        MainWindow = new MainWindow
        {
            DataContext = new MainWindowViewModel(bootstrapper.Host.Services.GetService<ICustomerService>()!, bootstrapper.Host.Services.GetService<ICustomerValidationService>()!)
        };
        MainWindow.Show();
    }
}
