using FraudPreditionTrainer.Schema;
using Microsoft.ML;

namespace FraudPreditionTrainer
{
    class Program
    {
        private static string DataPath = "Data/";
        static void Main(string[] args)
        {
            var mlContext = new MLContext(seed: 1);

            //Load
            var data = mlContext.Data.LoadFromTextFile<Transaction>(DataPath, hasHeader: true, separatorChar: ',');

            //Train

            //Transform

            //Evaluate

            //Save
        }
    }
}
