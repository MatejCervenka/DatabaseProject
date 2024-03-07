namespace DatabaseProject.Entities;

public class Customer
{
    private int Id { get; set; }
    private string Name { get; set; }
    
    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Customer: {Id}, Name: {Name}";
    }
}