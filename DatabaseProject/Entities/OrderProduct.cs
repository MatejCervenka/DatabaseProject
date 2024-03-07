namespace DatabaseProject.Entities;

public class OrderProduct
{
    private int Id { get; set; }
    private int OrderId { get; set; }
    private int ProductId { get; set; }
    private int Quantity { get; set; }

    public OrderProduct(int id, int orderId, int productId, int quantity)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"OrderProduct: {Id}, OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}";
    }
}