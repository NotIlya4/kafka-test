using Core.EntityFramework.Repositories;
using Core.Kafka;
using Core.Services;
using KafkaFlow;
using KafkaFlow.Serializer;

namespace Startup.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductNotifier, ProductNotifier>();
    }

    public static void AddConfiguredKafka(this IServiceCollection services, string broker)
    {
        services.AddKafka(
            kafka => kafka
                .UseConsoleLog()
                .AddCluster(
                    cluster => cluster
                        .WithBrokers(new [] { broker })
                        .CreateTopicIfNotExists(KafkaMetadata.CreateProductTopic, 1, 1)
                        .CreateTopicIfNotExists(KafkaMetadata.UpdateProductTopic, 1, 1)
                        .CreateTopicIfNotExists(KafkaMetadata.RemoveProductTopic, 1, 1)
                        .AddProducer(
                            KafkaMetadata.Producer,
                            producer => producer
                                .AddMiddlewares(m =>
                                    m.AddSerializer<JsonCoreSerializer>()
                                )
                        )
                )
        );
    }
}