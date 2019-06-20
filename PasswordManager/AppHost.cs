using System;

namespace PasswordManager
{
    public class AppHost
    {
        private readonly IDisplayConfiguration _displayConfiguration;

        public AppHost(IDisplayConfiguration displayConfiguration)
        {
            _displayConfiguration = displayConfiguration;
        }
        public void Run(string[] args)
        {
            Console.WriteLine(_displayConfiguration.AppDisplayName);

            Console.ReadKey();
        }
    }
}