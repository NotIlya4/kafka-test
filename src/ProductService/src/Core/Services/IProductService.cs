using Core.Domain.Entities;

namespace Core.Services;

public interface IProductService
{
    Task<List<Product>> Get();
    Task Add(CreateProductRequest request);
    Task Update(Product product);
}