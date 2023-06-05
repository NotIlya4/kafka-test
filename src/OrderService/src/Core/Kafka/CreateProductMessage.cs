namespace Core.Kafka;

public class CreateProductMessage
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Type { get; set; } = null!;
}