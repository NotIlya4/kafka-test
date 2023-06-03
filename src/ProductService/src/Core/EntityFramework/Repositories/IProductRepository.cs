using Core.Domain.Entities;

namespace Core.EntityFramework.Repositories;

public interface IProductRepository
{
    Task<List<Product>> Get();
    Task<Product> GetById(int id);
    Task Remove(int id);
    Task Add(Product product);
    Task Update(Product product);
}