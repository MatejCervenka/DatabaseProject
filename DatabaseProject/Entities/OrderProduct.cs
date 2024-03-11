using DatabaseProject.Interfaces;

namespace DatabaseProject.Entities
{
    /// <summary>
    /// Represents an entity class for an ordered product with a unique identifier (Id),
    /// associated order (OrderId), product (ProductId), and quantity.
    /// </summary>
    public class OrderProduct : IBaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ordered product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the ordered product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Default constructor for creating an empty OrderProduct instance.
        /// </summary>
        public OrderProduct()
        {
        }

        /// <summary>
        /// Parameterized constructor for creating an OrderProduct instance with specified values.
        /// </summary>
        /// <param name="id">The unique identifier of the ordered product.</param>
        /// <param name="orderId">The identifier of the associated order.</param>
        /// <param name="productId">The identifier of the associated product.</param>
        /// <param name="quantity">The quantity of the ordered product.</param>
        public OrderProduct(int id, int orderId, int productId, int quantity)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Parameterized constructor for creating an OrderProduct instance with specified values,
        /// where the unique identifier is initialized to 0.
        /// </summary>
        /// <param name="orderId">The identifier of the associated order.</param>
        /// <param name="productId">The identifier of the associated product.</param>
        /// <param name="quantity">The quantity of the ordered product.</param>
        public OrderProduct(int orderId, int productId, int quantity)
        {
            Id = 0;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Overrides the default ToString() method to provide a formatted string representation of the OrderProduct instance.
        /// </summary>
        /// <returns>A string representation of the OrderProduct instance.</returns>
        public override string ToString()
        {
            return $"OrderProduct: {Id}, OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}";
        }
    }
}
