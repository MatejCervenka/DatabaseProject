namespace DatabaseProject.Entities;

public class OrderProduct : IBaseClass
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public OrderProduct(int id, int orderId, int productId, int quantity)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }
    
    public OrderProduct(int orderId, int productId, int quantity)
    {
        Id = 0;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"OrderProduct: {Id}, OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}";
    }
}