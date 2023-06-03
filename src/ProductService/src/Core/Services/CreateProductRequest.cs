namespace Core.Services;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Type { get; set; } = null!;

    public CreateProductRequest(string name, decimal price, string type)
    {
        Name = name;
        Price = price;
        Type = type;
    }

    public CreateProductRequest()
    {
        
    }
}