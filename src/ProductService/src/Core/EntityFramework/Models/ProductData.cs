namespace Core.EntityFramework.Models;

public class ProductData
{
    public string Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string Type { get; private set; } = null!;

    public ProductData(string id, string name, decimal price, string type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }

    public ProductData()
    {
        
    }
}