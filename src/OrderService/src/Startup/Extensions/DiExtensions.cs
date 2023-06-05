using Core.Kafka;
using Core.Repositories;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;

namespace Startup.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void AddConfiguredKafka(this IServiceCollection services, string broker)
    {
        services.AddKafka(
            kafka => kafka
                .UseConsoleLog()
                .AddCluster(
                    cluster => cluster
                        .WithBrokers(new [] { broker })
                        .AddConsumer(consumer => consumer
                            .Topic(KafkaMetadata.CreateProductTopic)
                            .WithGroupId("order-service")
                            .WithWorkersCount(1)
                            .WithBufferSize(100)
                            .WithAutoOffsetReset(AutoOffsetReset.Earliest)
                            .AddMiddlewares(middlewares => middlewares
                                .AddSingleTypeSerializer<JsonCoreSerializer>(typeof(CreateProductMessage))
                                .AddTypedHandlers(h => h.AddHandler<CreateProductHandler>())
                            )
                        )
                )
        );
    }
}