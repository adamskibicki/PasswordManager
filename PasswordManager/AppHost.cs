using System;

namespace PasswordManager
{
    public class AppHost
    {
        private readonly IDisplayConfiguration _displayConfiguration;
        private readonly IPagesStorage _pagesStorage;

        public AppHost(IDisplayConfiguration displayConfiguration, IPagesStorage pagesStorage)
        {
            _displayConfiguration = displayConfiguration;
            _pagesStorage = pagesStorage;
        }

        public void Run(string[] args)
        {

            while (true)
            {
                string[] menuItems = new[]
                {
                    "1. Add page",
                    "2. Edit page",
                    "3. Remove page",
                    "4. Check for identical passwords",
                    "5. Search pages",
                    "6. Exit"
                };

                Console.WriteLine(_displayConfiguration.AppDisplayName);
                foreach (var menuItem in menuItems)
                {
                    Console.WriteLine(menuItem);
                }

                ConsoleKey key = Console.ReadKey().Key;

                Console.Clear();

                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Write page name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Write page url:");
                        string url = Console.ReadLine();
                        Console.WriteLine("Write page password:");
                        string password = Console.ReadLine();

                        _pagesStorage.Add(new Page {Name = name, Password = password, Url = url});

                        break;
                    case ConsoleKey.D6:
                        goto exit;
                }
            }

        exit:;
        }
    }
}