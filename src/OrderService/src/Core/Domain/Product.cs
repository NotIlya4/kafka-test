namespace Core.Domain;

public class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public Product(int id, decimal price)
    {
        Id = id;
        Price = price;
    }
    
    private Product()
    {
        
    }
}