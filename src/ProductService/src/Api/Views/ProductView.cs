namespace Api.Views;

public class ProductView
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string Type { get; private set; } = null!;

    public ProductView(Guid id, string name, decimal price, string type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }
}