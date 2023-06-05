namespace Core.Kafka;

public class KafkaMetadata
{
    public static string CreateProductTopic { get; } = "create-product";
    public static string UpdateProductTopic { get; } = "update-product";
    public static string RemoveProductTopic { get; } = "remove-product";
    public static string Producer { get; } = "producer";
}