using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FraudPredictionFunction
{
    public static class FraudPredictionFunction
    {
        [FunctionName("FraudPredictionFunction")]
        [return: EventHub("transaction-enriched-eh", Connection = "eventHubConnection")]
        public static async Task<string> Run(
            [EventHubTrigger("transaction-eh", Connection = "eventHubConnection")] string messageBody,
            [Blob("model/MLModel.zip", FileAccess.Read, Connection = "storageAccountConnection")] Stream model,
            ILogger log)
        {
            log.LogInformation("Fraud Prediction Function Called");

            var transaction = JsonConvert.DeserializeObject<Transaction>(messageBody);

            transaction.IsFraud = IsFraudulentTransaction(transaction, model);

            var result = JsonConvert.SerializeObject(transaction);

            return result;
        }

        private static bool IsFraudulentTransaction(Transaction transaction, Stream model)
        {
            var mlContext = new MLContext();
            var predictionPipeline = mlContext.Model.Load(model, out _);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, FraudPrediction>(predictionPipeline);

            return predictionEngine.Predict(transaction).IsFraud;         
        }
    }
}
