using CsvHelper;
using System.Collections.Generic;
using System.IO;
using TransactionSimulator.DataModels;

namespace TransactionSimulator.Services
{
    internal sealed class TransactionDataReader : ITransactionDataReader
    {
        public IEnumerable<Transaction> ReadTransactions()
        {
            using (TextReader reader = File.OpenText(@"/Users/bart/Downloads/Work.csv"))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ",";
                while (csv.Read())
                {
                    yield return csv.GetRecord<Transaction>();
                }
            }
        }
    }
}
