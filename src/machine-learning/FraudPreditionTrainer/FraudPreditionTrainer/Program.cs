using FraudPreditionTrainer.Schema;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

namespace FraudPreditionTrainer
{
    class Program
    {
        private static string DataPath = "Data/data.csv";

        static void Main(string[] args)
        {
            var mlContext = new MLContext(seed: 1);

            //Load
            var data = mlContext.Data.LoadFromTextFile<Transaction>(DataPath, hasHeader: true, separatorChar: ',');
            var testTrainData = mlContext.Data.TrainTestSplit(data);

            //Transform
            var dataProcessingPipeline = BuildDataProcessingPipeline(mlContext);

            //Train
            var trainingPipeline = dataProcessingPipeline
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "isFraud"));

            var trainedModel = trainingPipeline.Fit(testTrainData.TrainSet);

            //Evaluate
            var predictions = trainedModel.Transform(testTrainData.TestSet);
            var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "isFraud");

            //Save
            mlContext.Model.Save(trainedModel, data.Schema, "MLModel.zip");
        }

        static EstimatorChain<TransformerChain<NormalizingTransformer>> BuildDataProcessingPipeline(MLContext mlContext)
        {
            return mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameOrig"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameDest"))
                .Append(mlContext.Transforms.Concatenate("Features", "type", "nameOrig", "nameDest", "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest")
                .Append(mlContext.Transforms.NormalizeMinMax("Features")));
        }
    }
}
