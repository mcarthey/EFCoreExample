using Microsoft.Extensions.Configuration;

namespace EFCoreExample.Helpers;

public static class ConfigurationHelper
{
    public static IConfiguration GetConfiguration(string environmentName)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .Build();
    }
}