using Core.Domain.Entities;

namespace Core.Services;

public interface IProductService
{
    Task<List<Product>> Get();
    Task<Product> GetById(int productId);
    Task Add(CreateProductRequest request);
    Task Update(Product product);
    Task Remove(int productId);
}