using DatabaseProject.Interfaces;

namespace DatabaseProject.Entities;

public class Product : IBaseClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product()
    {
    }

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    
    public Product(string name, double price)
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