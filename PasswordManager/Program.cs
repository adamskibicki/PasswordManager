using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

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

            DisplayConfiguration displayConfiguration = configuration.Get<DisplayConfiguration>();

            Console.WriteLine(displayConfiguration.AppDisplayName);

            Console.ReadKey();
        }
    }

    public class DisplayConfiguration
    {
        public string AppDisplayName { get; set; }
    }
}
