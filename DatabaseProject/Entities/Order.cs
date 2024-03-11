using DatabaseProject.Interfaces;

namespace DatabaseProject.Entities
{
    /// <summary>
    /// Represents an entity class for an order with a unique identifier (Id),
    /// order date (OrderDate), and a flag indicating whether the order is shipped (IsShipped).
    /// </summary>
    public class Order : IBaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets a boolean flag indicating whether the order has been shipped.
        /// </summary>
        public bool IsShipped { get; set; }

        /// <summary>
        /// Default constructor for creating an empty Order instance.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Parameterized constructor for creating an Order instance with specified values.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <param name="orderDate">The date and time when the order was placed.</param>
        /// <param name="isShipped">A flag indicating whether the order has been shipped.</param>
        public Order(int id, DateTime orderDate, bool isShipped)
        {
            Id = id;
            OrderDate = orderDate;
            IsShipped = isShipped;
        }

        /// <summary>
        /// Parameterized constructor for creating an Order instance with specified values,
        /// where the unique identifier is initialized to 0.
        /// </summary>
        /// <param name="orderDate">The date and time when the order was placed.</param>
        /// <param name="isShipped">A flag indicating whether the order has been shipped.</param>
        public Order(DateTime orderDate, bool isShipped)
        {
            Id = 0;
            OrderDate = orderDate;
            IsShipped = isShipped;
        }

        /// <summary>
        /// Overrides the default ToString() method to provide a formatted string representation of the Order instance.
        /// </summary>
        /// <returns>A string representation of the Order instance.</returns>
        public override string ToString()
        {
            return $"Order: {Id}, OrderDate: {OrderDate}, IsShipped: {IsShipped}";
        }
    }
}
