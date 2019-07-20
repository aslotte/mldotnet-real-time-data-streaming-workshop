using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using TransactionSimulator.Configuration;
using TransactionSimulator.Services;

namespace TransactionSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = GetAppSettings();

            using (var loggerFactory = new LoggerFactory())
            {
                var transactionDataReader = new TransactionDataReader();
                var transactions = transactionDataReader.ReadTransactions().ToList();

                var eventHubService = new EventHubService(loggerFactory, appSettings.EventHubSettings);

                foreach (var transaction in transactions)
                {
                    eventHubService.SendMessageToEventHub(transaction);
                }

                Console.ReadLine();
            }
        }

        private static AppSettings GetAppSettings()
        {
            var appConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var appSettings = appConfig.Get<AppSettings>();
            return appSettings;
        }
    }
}
