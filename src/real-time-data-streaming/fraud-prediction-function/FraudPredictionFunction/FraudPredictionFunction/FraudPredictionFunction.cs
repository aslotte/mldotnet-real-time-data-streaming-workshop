using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FraudPredictionFunction
{
    public static class FraudPredictionFunction
    {
        [FunctionName("FraudPredictionFunction")]
        [return: EventHub("transaction-enriched-eh", Connection = "eventHubConnection")]
        public static async Task<string> Run(
            [EventHubTrigger("transaction-eh", Connection = "eventHubConnection")] string messageBody,
            ILogger log)
        {
            log.LogInformation("Fraud Prediction Function Called");

            var transaction = JsonConvert.DeserializeObject<Transaction>(messageBody);

            transaction.IsFraud = IsFraudulentTransacstion(transaction);

            var result = JsonConvert.SerializeObject(transaction);

            return result;
        }

        private static bool IsFraudulentTransacstion(Transaction transaction)
        {
            var mlContext = new MLContext();
            var predictionPipeline = mlContext.Model.Load(@"Data\MLModel.zip", out _);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, FraudPrediction>(predictionPipeline);

            return predictionEngine.Predict(transaction).IsFraud;         
        }
    }
}
