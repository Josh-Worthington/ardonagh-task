# Customer Details Application

This is a task assigned for the first stage interview with Ardonagh Advisory, the brief of the brief being to create a simple application which allows users to create and modify a list of "Customers" with a name, age, postcode and height, and validate each of those characteristics sensibly.

I ended up spending around 5 hours creating this application.

I chose to do the task using WPF as the frontend, as it is the frontend technology I am most familiar with.

## Design Decisions
There were a few key design decisions when it came to creating this application:
1. Separation of "database" contract from the view model contract

As I was using the MVVM (Model-View-ViewModel) architecture, I was leaning on its principles when deciding to create separate contracts for the data object `Customer` and the view model version `CustomerViewModel`. This is mainly to ensure that users are only interacting with the ViewModels on creation and modification, keeping the data object safe, and they can only "commit" changes once the validation is happy to let them (I keep using airquotes becauses it's all stored in memory, but important to keep safe data handling principles regardless).

2. Custom control over validation

I was initially using the WPF's own `ValidationRule` but in the end I wasn't happy that all of that logic was being tied up very closely to the frontend, and so decided to make my own service class `CustomerValidationService` to move the logic back into the "backend" of the application, where it could easily be extended and modified without introducing any breaking changes, and keeping business logic away from the frontend.

3. Templating the ViewModels

Instead of creating specific Views and setting the `DataContext` to be ViewModels in the code behind, I have instead created `DataTemplate`s, which look for a particular ViewModel, so any time that ViewModel is created it will automatically have that template assigned to it. I have always found this an easier and cleaner way of displaying ViewModels.

5. Use of MaterialDesignInXaml (http://materialdesigninxaml.net/)

From the get-go I decided to use a library for most of the styling of my front end components. This was mainly to save time while keeping things looking good, as I didn't want to have to spend hours combing over XAML to try and get the application looking as pretty as I usually like. Most of the interaction logic is still code I have written myself (Bindings and RelayCommands), aside from the `DialogHost` which provides very useful helper functions for creating modals in WPF applications.

## Issues

Currently don't think there is any issues with the application, it validates correctly and stores and modifies the in memory objects as expected.

The biggest challenge while actually creating the app for me was implementing the validation logic, I have found that WPF can be very particular in the way it handles property updates, and it has been a while since I have created any custom validation logic.

## Next Steps

The most obvious improvement would be to move the data storage from in memory to a database like SQLite. This would mean the user could pick up where they left off when the closed the application.

Another improvement I considered was calling out to some sort of public directory of UK addresses, to be able to validate the postcode more thoroughly, and only allow valid postcodes to be added.

I also would have probably spent more time making sure the dependency injection was setup across the whole application, instead of the way it is done currently (retrieving the services from the `Host` in the `MainWindow` and passing it into constructed ViewModels). The better way would be to use something like `Ninject` so that ViewModels are created from Factories, and any services required would be automatically injected.
