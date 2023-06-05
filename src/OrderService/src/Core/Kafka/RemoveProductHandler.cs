using Core.Kafka;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Core.Repositories;

public class RemoveProductHandler : IMessageHandler<RemoveProductMessage>
{
    private readonly IProductRepository _repository;

    public RemoveProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(IMessageContext context, RemoveProductMessage message)
    {
        await _repository.RemoveProduct(message.Id);
    }
}