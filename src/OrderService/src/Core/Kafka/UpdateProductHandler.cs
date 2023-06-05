using Core.Domain;
using Core.Repositories;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Core.Kafka;

public class UpdateProductHandler : IMessageHandler<Product>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(IMessageContext context, Product message)
    {
        await _repository.UpdateProduct(message);
    }
}