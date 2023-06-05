using Core.Domain;
using Core.Repositories;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Core.Kafka;

public class CreateProductHandler : IMessageHandler<CreateProductMessage>
{
    private readonly IProductRepository _repository;
    
    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(IMessageContext context, CreateProductMessage message)
    {
        await _repository.CreateProduct(new Product(message.Id, message.Price));
    }
}