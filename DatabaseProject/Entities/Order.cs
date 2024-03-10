namespace DatabaseProject.Entities;

public class Order : IBaseClass
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsShipped { get; set; }

    public Order()
    {
    }

    public Order(int id, DateTime orderDate, bool isShipped)
    {
        Id = id;
        OrderDate = orderDate;
        IsShipped = isShipped;
    }
    
    public Order(DateTime orderDate, bool isShipped)
    {
        Id = 0;
        OrderDate = orderDate;
        IsShipped = isShipped;
    }

    public override string ToString()
    {
        return $"Order: {Id}, OrderDate: {OrderDate}, IsShipped: {IsShipped}";
    }
}