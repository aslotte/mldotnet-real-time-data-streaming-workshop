using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnnxDemo
{
    class Program
    {
        private static readonly string ModelPath = "fraudulent-classifier-jupyter.onnx";

        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromEnumerable(CreateInputData());

            var pipeline = mlContext.Transforms.ApplyOnnxModel(ModelPath);

            var transformedValues = pipeline.Fit(data).Transform(data);

            var predictions = mlContext.Data
                .CreateEnumerable<PredictionResult>(transformedValues, reuseRowObject: false)
                .ToList();

            Console.WriteLine($"IsFraud: {predictions[0].IsFraud[0]}");
        }

        private static List<InputModel> CreateInputData()
        {
            float[] data = { 181, 0, 0, 0, 181, 439685, 0, 0, 0, 0, 1 };

            return new List<InputModel>
            {
                new InputModel
                {
                    Data = data
                }
            };
        }
    }
}
