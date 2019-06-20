using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .Build();

            IServiceCollection serviceCollection = new ServiceCollection()
                .AddSingleton<IDisplayConfiguration, DisplayConfiguration>(provider =>
                    configuration.Get<DisplayConfiguration>())
                .AddSingleton<IDynamoDbConfiguration, DynamoDbConfiguration>(provider =>
                    configuration.Get<DynamoDbConfiguration>())
                .AddSingleton<AppHost, AppHost>()
                .AddTransient<IPagesStorage, PagesStorage>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<AppHost>().Run(args);
        }
    }
}
