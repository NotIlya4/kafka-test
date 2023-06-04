using Core.Domain.Entities;

namespace Core.Kafka;

public interface IProductNotifier
{
    public Task ProductCreated(Product product);
    public Task ProductUpdated(Product product);
    public Task ProductRemoved(int productId);
}