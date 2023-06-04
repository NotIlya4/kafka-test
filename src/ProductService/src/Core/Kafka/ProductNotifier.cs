using Confluent.Kafka;
using Core.Domain.Entities;
using KafkaFlow;
using KafkaFlow.Producers;

namespace Core.Kafka;

public class ProductNotifier : IProductNotifier
{
    private readonly IMessageProducer _producer;

    public ProductNotifier(IProducerAccessor producerAccessor)
    {
        _producer = producerAccessor.GetProducer(KafkaMetadata.Producer);
    }

    public async Task ProductCreated(Product product)
    {
        await _producer.ProduceAsync(KafkaMetadata.CreateProductTopic, null!, product);
    }


    public async Task ProductUpdated(Product product)
    {
        await _producer.ProduceAsync(KafkaMetadata.UpdateProductTopic, null!, product);
    }


    public async Task ProductRemoved(int productId)
    {
        await _producer.ProduceAsync(KafkaMetadata.RemoveProductTopic, null!, new { Id = productId });
    }
}