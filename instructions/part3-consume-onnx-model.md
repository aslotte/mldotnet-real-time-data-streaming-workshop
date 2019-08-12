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
```   
var mlContext = new MLContext();
```
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
9. Right click on the project and select to add existing file
10. Select the downloaded .onnx file (also available [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/machine-learning/model/fraudulent-classifier-jupyter.onnx))
11. Change the file to copy always
12. Add path to file
```
private static readonly string ModelPath = "fraudulent-classifier-jupyter.onnx";
```
13. Load the data to be used for predictions
```
var data = mlContext.Data.LoadFromEnumerable(CreateInputData());
```
14. Create a prediction pipeline
```
var pipeline = mlContext.Transforms.ApplyOnnxModel(ModelPath);
```
15. Transform values and make predictions
```
var transformedValues = pipeline.Fit(data).Transform(data);

var predictions = mlContext.Data
   .CreateEnumerable<PredictionResult>(transformedValues, reuseRowObject: false)
   .ToList();
```

#### Summary
Congratulations, you've created your first prediction engine in ML.NET using an exported ONNX model!
A couple of things to point out here, the names of the columns for the input and output models are defined by the schema in the ONNX file. You can inspect the model schema in the pipeline if you are not sure about the names to start with. Once you know the names, make sure decorate the respective properties with the `[ColumnName()]` attribute.

Secondly, the input to the model is an array of float values. In contrast to our prediction engine in ML.NET where we can pass in the raw data (and the prediction engine handles the transformations) there is a need to pre-process the data here if we would use this in production. We also need to specify the expected length of the vector, in our case we have 13 features thus specifiying it as `[VectorType(13)]`

A finished solution can be found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/FraudPredictorOnnx)
