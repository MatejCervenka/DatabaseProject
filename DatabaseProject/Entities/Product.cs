namespace DatabaseProject.Entities;

public class Product
{
    private int Id { get; set; }
    private string Name { get; set; }
    private float Price { get; set; }

    public Product(int id, string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    
    public Product(string name, float price)
    {
        Id = 0;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"Product: {Id}, Name: {Name}, Price: {Price}";
    }
}