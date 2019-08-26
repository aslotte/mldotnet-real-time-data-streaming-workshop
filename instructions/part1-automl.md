
## Training your model using ML.NET's AutoML 
Selecting the correct features, algorithms, hyper arameters and so forth is complex. There is a lot of trial and error involved until you've managed to fine-tune a model to not only have good enough accuracy but also a decent area under the precision-recall curve.
To simplify, ML.NET has introduced AutoML to automatically iterate through numerous algorithms with various hyper parameters to find one that yields a good model.

### Pre-requisites
- [ML.NET CLI](https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/install-ml-net-cli)

### Training a model using AutoML CLI
Once the [ML.NET CLI](https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/install-ml-net-cli) have been installed we can use the `mlnet auto-train` command to automatically create our model

1. Open a PowerShell or Command prompt 
2. Navigate to the location of your data file
3. Execute
```
mlnet auto-train --dataset "data.csv" --label-column-name "isFraud" --max-exploration-time 120 --has-heade
r true --ml-task binary-classification
```

For this example we are setting the max-exploration time to only 2 minutes, which is not sufficient for a data-set of this size but serves as a good example to showcase the functionality. A minimum of 1800 seconds is recommended for a data-set of this size.

AutoML is a tremendous addition to the ML.NET toolset. Not only does it create a ready to go model based on the best algorithm, but it also creates a sample application with the code used to come up with this model for further fine-tuning. 

It is also possible to use AutoML through Visual Studio. If you would like to do that, please download the Model Builder Visual Studio Extension which will give you a nice UI to work with.

### Exploring the sample solution
Open the sample solution created by the AutoML CLI tool once completed (the path to the solution will be given in the terminal window).
Do you notice any differenes with the solution you created earlier?
