namespace DatabaseProject.Entities;

public class Customer : IBaseClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Customer()
    {
    }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public Customer(string name)
    {
        Id = 0;
        Name = name;
    }

    public override string ToString()
    {
        return $"Customer: {Id}, Name: {Name}";
    }
}