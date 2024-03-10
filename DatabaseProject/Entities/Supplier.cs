namespace DatabaseProject.Entities;

public class Supplier : IBaseClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Supplier()
    {
    }

    public Supplier(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public Supplier(string name)
    {
        Id = 0;
        Name = name;
    }
    
    public override string ToString()
    {
        return $"Supplier: {Id}, Name: {Name}";
    }
}