using Microsoft.Extensions.Configuration;

namespace CashFlow.Infrastructure.Extensions;
public static class ConfigurationExtensions
{
    public static bool IsTestEnvironment(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("InMemoryTest");
    }
}
