using Core.Domain;

namespace Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> Get();
    Task CreateProduct(Product product);
    Task UpdateProduct(Product product);
    Task RemoveProduct(int productId);
}