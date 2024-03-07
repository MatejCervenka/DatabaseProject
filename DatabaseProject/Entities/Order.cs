namespace DatabaseProject.Entities;

public class Order
{
    private int Id { get; set; }
    private DateTime OrderDate { get; set; }
    private bool IsShipped { get; set; }

    public Order(int id, DateTime orderDate, bool isShipped)
    {
        Id = id;
        OrderDate = orderDate;
        IsShipped = isShipped;
    }

    public override string ToString()
    {
        return $"Order: {Id}, OrderDate: {OrderDate}, IsShipped: {IsShipped}";
    }
}