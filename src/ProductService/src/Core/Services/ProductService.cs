using Core.Domain.Entities;
using Core.EntityFramework.Repositories;

namespace Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> Get()
    {
        return await _repository.Get();
    }

    public async Task Add(CreateProductRequest request)
    {
        await _repository.Add(new Product(id: 0, name: request.Name, price: request.Price, type: request.Type));
    }

    public async Task Update(Product product)
    {
        await _repository.Update(product);
    }
}