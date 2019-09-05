### Consume ONNX Model from a Jupyter Notebook in ML.NET
The Open Neural Network Exchange (ONNX) standard is backed by multiple large organizations such as Google, Facebook and Microsoft.
The standard allows models trained in libraries such as Scikit Learn, Pytorch, Tensorflow or ML.NET to be used interchangeably.

In part 3 we trained a model using Scikit Learn in a Jupyter Notebook. A finished Scikit Learn model takes the form of a .pkl file, which we are unable to use in ML.NET. However, as the example also demonstrates, the model can be exported to the .onnx format, which ML.NET is able to work with.

In this section we'll create a small ML.NET console application that will utilize the .onnx model to make predictions.
Please follow the steps below: 

   - Open VS Code</br>
   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br>
   - In the terminal, execute `cd C:\mldotnet-real-time-data-streaming-workshop\workspace` to navigate to your workspace folder
   - In the terminal, execute `dotnet new console -o FraudulentOnnx` 
   - In the terminal, execute `cd FraudulentOnnx` to navigate in to your newly created solution
   - In the terminal, execute `dotnet add package Microsoft.ML` 
   - In the terminal, execute `dotnet add package Microsoft.ML.OnnxTransformer`
   - Open the `Program.cs` file
   - In the `Main` method, add an `MLContext`
```   
var mlContext = new MLContext();
```
   - Create a new class called `InputModel.cs`
```
using Microsoft.ML.Data;

namespace FraudulentOnnx
{
    class InputModel
    {
        [VectorType(11)]
        [ColumnName("float_input")]
        public float[] Data { get; set; }
    }
}
```
   - Create a new class called `PredictionResult.cs`
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
   - In the `Program.cs` class, add a method for `CreateInputData` to create sample data to be used for the prediction (same as in the Jupyter Notebook)
```
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
```
   - Copy the downloaded .onnx file in your solutions folder (also available [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/machine-learning/model/fraudulent-classifier-jupyter.onnx))
   - Open the `FraudulentOnnx.csproj` file
   - Add the following to allow the .onnx file to be copied on build
```
<ItemGroup>
  <None Update="fraudulent-classifier-jupyter.onnx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>   
```

   - In the `Program.cs` class, above the `Main` method, add a path to the model
```
private static readonly string ModelPath = "fraudulent-classifier-jupyter.onnx";
```
   - In the `Program.cs` class, add the following
```
var data = mlContext.Data.LoadFromEnumerable(CreateInputData());
```
   - Add the following line to create a prediction pipeline
```
var pipeline = mlContext.Transforms.ApplyOnnxModel(ModelPath);
```
   - To transform  your values and make predictions, please add the following lines
```
var transformedValues = pipeline.Fit(data).Transform(data);

var predictions = mlContext.Data
   .CreateEnumerable<PredictionResult>(transformedValues, reuseRowObject: false)
   .ToList();
```
   - Hit F5 to run your application
   
#### Summary
Congratulations, you've created your first prediction engine in ML.NET using an exported ONNX model!
A couple of things to point out here, the names of the columns for the input and output models are defined by the schema in the ONNX file. You can inspect the model schema in the pipeline if you are not sure about the names to start with. Once you know the names, make sure decorate the respective properties with the `[ColumnName()]` attribute.

Secondly, the input to the model is an array of float values. In contrast to our prediction engine in ML.NET where we can pass in the raw data (and the prediction engine handles the transformations) there is a need to pre-process the data here if we would use this in production. We also need to specify the expected length of the vector, in our case we have 13 features thus specifiying it as `[VectorType(13)]`

A finished solution can be found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/FraudPredictorOnnx)
