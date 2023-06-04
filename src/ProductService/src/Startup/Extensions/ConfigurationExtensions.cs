using NotIlya.Extensions.Configuration;

namespace Startup.Extensions;

public static class ConfigurationExtensions
{
    public static string GetKafkaBroker(this IConfiguration config)
    {
        return config.GetRequiredValue("KafkaBroker");
    }
}