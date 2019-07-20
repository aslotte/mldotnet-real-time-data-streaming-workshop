using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TransactionSimulator.DataModels;

namespace TransactionSimulator.Services
{
    internal sealed class TransactionDataReader : ITransactionDataReader
    {
        public IEnumerable<Transaction> ReadTransactions()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(basePath, @"Data\simulator-data.csv");

            using (TextReader reader = File.OpenText(filePath))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.HeaderValidated = null;

                csv.Configuration.Delimiter = ",";
                while (csv.Read())
                {
                    yield return csv.GetRecord<Transaction>();
                }
            }
        }
    }
}
