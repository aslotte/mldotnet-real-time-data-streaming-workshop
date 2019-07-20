using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TransactionSimulator.Configuration;
using TransactionSimulator.DataModels;

namespace TransactionSimulator
{
    internal sealed class EventHubService : IEventHubService
    {
        private readonly EventHubClient eventHubClient;
        private readonly EventHubSettings eventHubSettings;
        private readonly ILogger logger;

        internal EventHubService(ILoggerFactory loggerFactory, EventHubSettings eventHubSettings)
        {
            this.logger = loggerFactory.CreateLogger(nameof(EventHubService));
            this.eventHubSettings = eventHubSettings;
            this.eventHubClient = InitializeEventHub();
        }

        public async Task SendMessageToEventHub(Transaction transaction)
        {
            var message = JsonConvert.SerializeObject(transaction);
            logger.LogInformation("Calling the EventHub");

            await this.eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));

            logger.LogInformation("The EventHub called succesfully");
        }

        private EventHubClient InitializeEventHub()
        {
            logger.LogInformation("Initializing an EventHub client");

            var ehConnectionString = eventHubSettings.EventHubConnectionString;

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(ehConnectionString)
            {
                EntityPath = eventHubSettings.EventHubPath
            };
            return EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }
    }
}
