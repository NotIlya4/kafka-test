using Core.Domain.Entities;

namespace Core.EntityFramework.Repositories;

public interface IProductRepository
{
    Task<List<Product>> Get();
    Task<Product> GetById(Guid id);
    Task Remove(Guid id);
    Task Add(Product product);
    Task Update(Product product);
    Task Put(Product product);
}