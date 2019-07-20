namespace TransactionSimulator.Configuration
{
    internal sealed class AppSettings
    {
        public EventHubSettings EventHubSettings { get; set; }
        public TransactionDataSettings transactionDataSettings { get; set; }
    }
}
