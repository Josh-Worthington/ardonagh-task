namespace CustomerDetails.Interfaces.Entities;

public interface ICustomer
{
    /// <summary>
    ///     Gets the id of the customer.
    /// </summary>
    int Id { get; }

    /// <summary>
    ///     Gets or sets the name of the customer.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    ///     Gets or sets the age of the customer.
    /// </summary>
    int Age { get; set; }

    /// <summary>
    ///     Gets or sets the postcode of the customer.
    /// </summary>
    string Postcode { get; set; }

    /// <summary>
    ///     Gets or sets the height of the customer.
    /// </summary>
    double Height { get; set; }
}
