namespace Api;

public class CreateProductRequestView
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Type { get; set; } = null!;

    public CreateProductRequestView(string name, decimal price, string type)
    {
        Name = name;
        Price = price;
        Type = type;
    }

    public CreateProductRequestView()
    {
        
    }
}