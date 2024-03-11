using DatabaseProject.Interfaces;

namespace DatabaseProject.Entities
{
    /// <summary>
    /// Represents an entity class for a customer with a unique identifier (Id)
    /// and a name.
    /// </summary>
    public class Customer : IBaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default constructor for creating an empty Customer instance.
        /// </summary>
        public Customer()
        {
        }

        /// <summary>
        /// Parameterized constructor for creating a Customer instance with specified values.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Parameterized constructor for creating a Customer instance with specified values,
        /// where the unique identifier is initialized to 0.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        public Customer(string name)
        {
            Id = 0;
            Name = name;
        }

        /// <summary>
        /// Overrides the default ToString() method to provide a formatted string representation of the Customer instance.
        /// </summary>
        /// <returns>A string representation of the Customer instance.</returns>
        public override string ToString()
        {
            return $"Customer: {Id}, Name: {Name}";
        }
    }
}