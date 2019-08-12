### Consume ONNX Model from a Jupyter Notebook in ML.NET
The Open Neural Network Exchange (ONNX) standard is backed by multiple large organizations such as Google, Facebook and Microsoft.
The standard allows models trained in libraries such as Scikit Learn, Pytorch, Tensorflow or ML.NET to be used interchangeably.

In part 3 we trained a model using Scikit Learn in a Jupyter Notebook. A finished Scikit Learn model takes the form of a .pkl file, which we are unable to use in ML.NET. However, as the example also demonstrates, the model can be exported to the .onnx format, which ML.NET is able to work with.

In this section we'll create a small ML.NET console application that will utilize the .onnx model to make predictions.
Please follow the steps below: 

1. Open Visual Studio
2. Create an empty .NET Core Console application, name it e.g. FraudulentOnnx
3. Right-click on the solution and select to "Manage NuGet packages"
4. Install the following packages
   - Microsoft.ML
   - Microsoft.ML.OnnxTransformer
5. Create an MLContext
    `var mlContext = new MLContext();`
6. Create an input class callled `InputModel`
```
using Microsoft.ML.Data;

namespace OnnxDemo
{
    class InputModel
    {
        [VectorType(13)]
        [ColumnName("float_input")]
        public float[] Data { get; set; }
    }
}
```
7. Create an output prediction called `PredictionResult`
```
using Microsoft.ML.Data;
using System;

namespace OnnxDemo
{
    class PredictionResult
    {
        [ColumnName("output_label")]
        public Int64[] IsFraud { get; set; }
    }
}
```
8. Create a method in Program.cs to create sample data to be used for the prediction (same as in the Jupyter Notebook)
```
        private static List<InputModel> CreateInputData()
        {
            float[] data = { 1, 2806.0f, 1379875, 2806.0f, 0, 563886.0f, 0f, 0f, 0f, 0f, 0f, 0f, 1 };

            return new List<InputModel>
            {
                new InputModel
                {
                    Data = data
                }
            };
        }
```
