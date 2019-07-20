using System.Threading.Tasks;
using TransactionSimulator.DataModels;

namespace TransactionSimulator
{
    internal interface IEventHubService
    {
        Task SendMessageToEventHub(Transaction transaction);
    }
}
