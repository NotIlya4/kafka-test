namespace Startup.Extensions;

public class AddKafkaOptions
{
    public IEnumerable<string> Brokers { get; }

    public AddKafkaOptions(IEnumerable<string> brokers)
    {
        Brokers = brokers;
    }
}