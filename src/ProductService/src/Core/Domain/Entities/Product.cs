namespace Core.Domain.Entities;

public record Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string Type { get; }

    public Product(Guid id, string name, decimal price, string type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }
}