using CustomerDetails.Interfaces.Entities;

namespace CustomerDetails.Entities;

/// <summary>
///     The customer.
/// </summary>
/// <param name="id">The id of the customer.</param>
/// <param name="name">The name of the customer.</param>
/// <param name="age">The age of the customer.</param>
/// <param name="postCode">The postcode of the customer.</param>
/// <param name="height">The height of the customer.</param>
public class Customer(int id, string name, int age, string postCode, double height) : ICustomer
{
    /// <inhertdoc/>
    public int Id { get; init; } = id;

    /// <inheritdoc/>
    public string Name { get; set; } = name;

    /// <inheritdoc/>
    public int Age { get; set; } = age;

    /// <inheritdoc/>
    public string Postcode { get; set; } = postCode;

    /// <inheritdoc/>
    public double Height { get; set; } = height;
}
