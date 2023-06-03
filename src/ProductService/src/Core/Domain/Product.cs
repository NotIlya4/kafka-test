namespace Core.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Type { get; set; } = null!;

    public Product(int id, string name, decimal price, string type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }
    
    private Product()
    {
        
    }
}