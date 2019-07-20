using System.Collections.Generic;
using TransactionSimulator.DataModels;

namespace TransactionSimulator.Services
{
    internal interface ITransactionDataReader
    {
        IEnumerable<Transaction> ReadTransactions()
    }
}
