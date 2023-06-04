using Core.Domain.Entities;
using Core.EntityFramework.Repositories;
using Core.Kafka;

namespace Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IProductNotifier _notifier;

    public ProductService(IProductRepository repository, IProductNotifier notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }

    public async Task<List<Product>> Get()
    {
        return await _repository.Get();
    }

    public async Task<Product> GetById(int productId)
    {
        return await _repository.GetById(productId);
    }

    public async Task Add(CreateProductRequest request)
    {
        await _repository.Add(new Product(id: 0, name: request.Name, price: request.Price, type: request.Type));
        Product product = await _repository.GetByName(request.Name);
        await _notifier.ProductCreated(product);
    }

    public async Task Update(Product product)
    {
        await _repository.Update(product);
        await _notifier.ProductUpdated(product);
    }

    public async Task Remove(int productId)
    {
        await _repository.Remove(productId);
        await _notifier.ProductRemoved(productId);
    }
}