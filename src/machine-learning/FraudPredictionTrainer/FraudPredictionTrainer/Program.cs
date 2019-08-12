using FraudPreditionTrainer.Schema;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using System;

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
            var trainingPipeline = BuildTrainingPipeline(mlContext, dataProcessingPipeline);

            var trainedModel = trainingPipeline.Fit(testTrainData.TrainSet);

            //Evaluate
            var predictions = trainedModel.Transform(testTrainData.TestSet);
            var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "isFraud");

            Console.WriteLine($"Accuracy: {metrics.Accuracy}");
            Console.WriteLine($"AUCPC: {metrics.AreaUnderPrecisionRecallCurve}");
            Console.WriteLine($"Recall: {metrics.PositiveRecall}");
            Console.WriteLine($"Precision: {metrics.PositivePrecision}");

            //Save
            mlContext.Model.Save(trainedModel, data.Schema, "MLModel.zip");
        }

        private static IEstimator<ITransformer> BuildDataProcessingPipeline(MLContext mlContext)
        {
            return mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotHashEncoding("nameDest"))
                .Append(mlContext.Transforms.Concatenate("Features", "type", "nameDest", "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest")
                .Append(mlContext.Transforms.NormalizeMinMax("Features")));
        }

        private static IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext, IEstimator<ITransformer> dataProcessingPipeline)
        {
            return dataProcessingPipeline.Append(mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options() { NumberOfLeaves = 10, NumberOfTrees = 500, LabelColumnName = "isFraud", FeatureColumnName = "Features" }));
        }
    }
}
