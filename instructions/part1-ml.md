### Training your Machine Learning Model using ML.NET
In this section we will be training our Machine Learning model by first manually writing the code to do so, and then looking at how ML.NET may automatically generate a model for you.

#### Using a Machine Learning Pipeline in .NET
To build your machine learning model using ML.NET, please refer to the instructions below:
<details>
  <summary>Instructions</summary>
<br/>
So you're ready to start creating your Machine Learning model in ML.NET? Awesome!
ML.NET is an open-source, cross-platform library, released to the public in preview during MS Build 2018 and for general availability at MS Build 2019. It bridges the gap between Software Engineering and Data Science, and allows .NET Developers to make their applications smarter.
</br></br>
The general steps for training your model are the same regardless if you are training your model using ML.NET or a Python based library such as Scikit Learn. To train your model in ML.NET, please expand and follow the instructions below:
</br><br/>
<details>
  <summary><b>1. Determine your problem domain </b></summary>
  <p>

Framing the business problem you are attempting to solve is absolute key for a successful machine learning project. A lot of the times, people attempt to start with either a cool algorithm or just the data they have, but without a clear understanding of the problem they are trying to solve. Furthermore, without a dialog with Subject Matter Experts (SME's), crucial data may be overlooked and business value may not be provided.

  </p>
</details>
<details>
  <summary><b>2. Gather and load your data</b></summary>
    <p>
      
Once the problem has been defined, it's time to gather our data. Data is normally gathered from multiple sources (both public and private), and then aggregated and pivoted in to a workable shape. For our purposes, the data we will be using can be retrieved from [Kaggle](https://www.kaggle.com/ntnu-testimon/paysim1). You should already have downloaded the data as part of getting started.
      
Other available data-sources worth exploring are: 
   - [Google Public Datasets](https://cloud.google.com/public-datasets/)  
   - [AWS Open Data](https://aws.amazon.com/opendata/)  
   - [Open Government Data](https://www.data.gov/)  
   - [EU Open Data](https://data.europa.eu/euodp/en/data)  
   
  <details>
    <summary><b>2.1 Explore the dataset</b></summary>
   <p>
   
   Exploring a large dataset can be daunting. Loading a dataset containing 6+ million rows in something like Excel is not always feasible due to application limitations and performance. To make life easier for us we can use an open-source Python library called **Pandas** in e.g. a Jupyter notebook.
   
   To explore the dataset using Pandas and a Jupyter notebook:
   - Create a free [Kaggle account](https://www.kaggle.com/)
   - Navigate to the [Dataset](https://www.kaggle.com/ntnu-testimon/paysim1) and click "New Notebook". 
   - When selecting Kernel type, select **Notebook**
   - In the top-left corner, select File -> Upload Notebook
   - Upload the [Jupyter notebook](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/machine-learning/jupyter/fraudulent-transactions-jupyter-notebook.ipynb) from this repo
   - Select Run -> Run all
   - Explore the results
   
   **Questions to think about:**
   - What kind of features are we working with?(columns)<br/>
   - Which column is considered your label column (what we would like to predict)?<br/>
   - Is the dataset balanced? (hint: what's the distribution of fraudulent and non-fraudulent transactions)<br/>
   - What's the data type of the available features?<br/>
   - Does any of the columns have missing values?<br/>   
   </p>
  </details>
  <details>
    <summary><b>2.2 Getting started with ML.NET</b></summary>
    <p>
      
   Fantastic, you have gathered the required data and are now ready to dive in to ML.NET.</br>
   ML.NET is distributed as a NuGet package and can be installed like any other package.</br>
   </br>
   The first step is to create a new console application</br>
   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br>
   - In the terminal window, execute the following command to navigate to the workspace folder.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\workspace`
   ![navigate](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-to-workspace.PNG)</br>
   - In the terminal window, execute the following command to create a new solution.</br>`dotnet new console -o FraudPredictionTrainer`
      ![source](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-create-solution.PNG)</br>
   - In the terminal window, execute the following command `cd FraudPredictionTrainer` to navigate in to the folder of the newly created solution ![navigatetofolder](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-navigate-in-to-folder.PNG)</br>
</br>

Once we have created our solution, we will need to install the required NuGet packages.</br>
In the previously open terminal window, copy/paste and execute the following below commands</br>
   - `dotnet add package Microsoft.ML`<br/>
   - `dotnet add package Microsoft.ML.FastTree`<br/>
   - `dotnet add package Microsoft.ML.LightGbm`<br/>

To browse the solution:</br>
- In the terminal window, execute the following command `code . -r` to open VS Code in the folder
![navigatetofolder](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-folder.PNG)</br>
- Click **Yes** if asked to add build assets
- Open the project file to the left. The content should look as below
![projectfile](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-project-file.PNG)</br>

The next step is to include our previously downloaded `data.csv` file in the solution.
  - Copy the previously downloaded `data.csv` file to</br> `C:\mldotnet-real-time-data-streaming-workshop\workspace\FraudPredictionTrainer`
  - In the open project file, copy/paste the below snippet.</br>This will ensure the `data.csv` is copied out to the bin folder upon build, so that it can be used by ML.NET.</br>   
   ```
<ItemGroup>
  <None Update="data.csv">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>
```
 - The project file should now look like:
 ![projectfile](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-project-file-2.PNG)
 - Open a new terminal window and execute `dotnet build` to ensure everything is setup correctly.
 ![projectfile](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-dotnet-build.PNG)</br><br/>

Alright, setup complete! Great work so far.</br>
Before we jump in to the code, let me introduce two concepts of ML.NET that will be mentioned a fair bit; pipelines and the MLContext. 
   
**The MLContext** contains the data loaders, transformers, algorithms and event the evaluation tools that one may need. </br>
**Pipelines** is a paradigm in ML.NET, in which we create an object to which we chain multiple operations, such as data transformations and training algorithms.
   
   To get started, let's create an MLContext. 
   
   ```
    var mlContext = new MLContext(seed: 1);
   ```
   
   Setting the property seed to 1 ensures deterministic randomness in operations such as splitting test/train data, which is normally desired.    
   
   Furthermore, add a using statement for ML.NET
   ```
    using Microsoft.ML;
   ```   
   
   The `Program.cs` file should currently look as below:
   ![programcs1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-program-1.PNG)
   </p>
  </details>
  <details>
    <summary><b>2.3 Load your data in ML.NET</b></summary>
    <p>

The Data Catalog of the MLContext (F12 in the class if you are curious) contains a number of ways you can load your data in to memory. To just mention a couple, we can load data from binary, from file and from a SQL database. In this example, we will be loading our data from our comma-separated file. To do this, let's start by defining where the file resides. 
   
   Add a static member variable above the main method, but within the class:
   
   ```
    private static string DataPath = "data.csv";
   ```        
   
To load our data, we'll need to tell ML.NET what the schema of our data looks like. Just as this is done in Entity Framework, we can do this by creating a simple POCO, with a property for each column in the dataset. Each property needs to be decorated with the `LoadColumn` and `ColumnName` attributes, which defines the index of the column in the data, as well as its name. Furthermore, note that ML models are only able to work with float vectors, thus any column containing numerical data will have to have a corresponding property defined of type `float`. We will later see how we can transform non-numerical data to a numerical form.</br></br>
To define a schema, create a new file called `Transaction.cs` and copy/paste the below code

```
using Microsoft.ML.Data;

namespace FraudPredictionTrainer 
{
    internal sealed class Transaction
    {
        [ColumnName("step"), LoadColumn(0)]
        public float Step { get; set; }

        [ColumnName("type"), LoadColumn(1)]
        public string Type { get; set; }

        [ColumnName("amount"), LoadColumn(2)]
        public float Amount { get; set; }

        [ColumnName("nameOrig"), LoadColumn(3)]
        public string NameOrig { get; set; }

        [ColumnName("oldbalanceOrg"), LoadColumn(4)]
        public float OldbalanceOrg { get; set; }

        [ColumnName("newbalanceOrig"), LoadColumn(5)]
        public float NewbalanceOrig { get; set; }

        [ColumnName("nameDest"), LoadColumn(6)]
        public string NameDest { get; set; }

        [ColumnName("oldbalanceDest"), LoadColumn(7)]
        public float OldbalanceDest { get; set; }

        [ColumnName("newbalanceDest"), LoadColumn(8)]
        public float NewbalanceDest { get; set; }

        [ColumnName("isFraud"), LoadColumn(9)]
        public bool IsFraud { get; set; }

        [ColumnName("isFlaggedFraud"), LoadColumn(10)]
        public float IsFlaggedFraud { get; set; }
      }
}
```
   
   To load the data with the given schema, open the Program.cs file and add the following line: 
   
      var data = mlContext.Data.LoadFromTextFile<Transaction>(DataPath, hasHeader: true, separatorChar: ',');
      
  The generic `LoadFromTextFile` method takes the location of the data file. We will also need to define if the data has headers and how it is separated. </br></br>
  The `Program.cs` file should currently look as below:
     ![aftertransaction](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-transaction.PNG)
  
 </p>
</details>
</p>
</details>
<details>
<summary><b>3. Split your data in a test and training set</b></summary>
  <p>
    
A crucial part of training a machine learning model, is to be able to evaluate its performance on data not utilized during training. Thus, before starting to train our model, we want to make sure we put a portion of the data aside for evaluation purposes.

ML.NET features built-in functionality to perform a random split of the data in to a training and test set. </br>
The created instance will have a `TrainSet` and a `TestSet` property.</br>

To split the data, add the following line to your code:

      var testTrainData = mlContext.Data.TrainTestSplit(data);
      
Note that splitting your data in to a train and test set is not always required. A technique called cross-validation can also be utilized to achieve similar, if not better result.</br>

Our `Program.cs` file should now look as below:
![aftersplit](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-split.PNG)

  </p>
</details>
<details>
<summary><b>4. Transform your data</b></summary>
  <p>
    
The dataset from Kaggle is in an overall great condition, as opposed to how it could look. The variables are neatly contained in columns, thus no pivoting of the data is needed. The data contains no missing values that needs to be replaced.
   
Machine Learning models are very picky in terms of data quality, so making sure that the data is top-notch is critical. We want to make sure that no columns have missing values, that the data is reasonable balanced and that no obvious outliers exists. The only main-concern we have with our data is that it is highly unbalanced. The number of fraudulent transactions to train the data on is just a couple of percent's of the total dataset. If we were able to, we would ideally include additional fraudulent transactions to balance the data, but as this is not possible we will apply other techniques to counter this in a later step.

As previously mentioned, machine learning algorithms function best on numerical data, and has a difficult time working with textual values. Our dataset currently contains two non-numerical features, **type** and **nameDest**. We could ofcourse also look at the **nameOrig** column, but we can assume that the victims are chosen at random, so this column may not hold much predictable power and can be discarded.

To transform these features to float vectors, we can utilize a technique called `OneHotEncoding` which will create new binary columns for each value present in the feature space. For example, the type column contains values such as "Payment" and "Transfer". If we apply `OneHotEncoding` on the type column, ML.NET will create new columns such as IsPayment, IsTransfer with a binary response, either 1 or 0 to indicate the type. This approach greatly increases the performance of the algorithm and allows it to converge to an optimal solution.

To transform the type column using `OneHotEncoding`, you can call the `OneHotEncoding` method located in the Transforms catalog of ML.NET

    mlContext.Transforms.Categorical.OneHotEncoding("type")

The cardinality of the nameDest column however, is likely to be very high, thus regular `OneHotEncoding` would create a very wide dataset, causing either a large model or an out-of-memory exception when performing the training. We can instead use `OneHotHashEncoding` to reduce the dimensions and save some space.

At this point, this is very pipelines come in to play. As we will have multiple transformation operations we would like to conduct, we can chain them all together in to a data processing pipeline:
 
    var dataProcessingPipeline = mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotHashEncoding("nameDest"))
                
 Perfect. Our non-numeric features are now transformed into a form the algorithm can understand.</br>
 
So which features do you think account for the variance in the dataset? Or put in another way, which features do you think are relevant  to include in our model? Feature engineering is a difficult topic. It's very likely that additional features may be needed to achieve a better model, or derived features of the existing featureset may yield a better outcome. This is where it is very important to consult with a subject matter expert to understand the problem domain you're in, and what data may be relevant. For our purposes, we can start off by trying to include more or less all columns in our model, as we only have seven or so features (you may have thousands if not more in real-world example). 
 
 To define which features to include during training, we will have to concatenate them in to a `Feature` vector
 This can be done by using the `Concatenate` method located in the `Transforms` catalog
 
       mlContext.Transforms.Concatenate("Features", "type", "nameDest", "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest")
       
 To add the required transformations, add the below lines to your `Program.cs` file.
 
            var dataProcessingPipeline = mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotHashEncoding("nameDest"))
                .Append(mlContext.Transforms.Concatenate("Features", "type", "nameDest", 
                "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest"));
 
 The `Program.cs` file should now look as below
 ![afterTransformations](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-transformations.PNG)
 
  </p>
</details>
<details>
<summary><b>5. Train your model</b></summary>
  <p>
    
 Once we have created our data processing pipeline it's time to select the trainer (algorithm) to use. 
 
 The most common types of algorithms to use are:
    
   - Linear Regression <br/>
   - Nearest Neighbor <br/>
   - Naive Bayes <br/>
   - Decision Trees <br/>
   - Support Vector Machines (SVM) <br/>
   
   Each family of algorithms has its pros and cons as we will see later in this workshop, but for simplicities sake, lets start off with the most straightforward algorithm, linear regression. A variant of linear regression is logistic regression. 
   So where can we find the available trainers in ML.NET? 
   The trainers are located under the given ML Task we are trying to perform. In our case we are attempting to do something called `BinaryClassification`, which is to predict one out of two possible values (thus binary). Other common ML tasks are Multi-Class Classification (three or more values), regression, clustering, anomaly detection and recommender systems.
   
   We can create a training pipeline using logistic linear regression by appending the `LbfgsLogisticRegression` trainer to our previously created data processing pipeline. The `LbfgsLogisticRegression` requires us to define which column in the dataset is contains our labels, the value we are trying to predict</br>
   To do this, add the below lines of code to your `Program.cs` file
   
    var trainingPipeline = dataProcessingPipeline
        .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "isFraud"));
   
  Once we have appended the trainer, all that remains is to use the `trainingPipeline` to a fit an as accurate model as possible based on the training dataset. To do this, we will use the `.Fit` method located on the `IEstimator` interface.</br>
  Add the below line of code to your `Program.cs` file

    var trainedModel = trainingPipeline.Fit(testTrainData.TrainSet);
  
 The `Program.cs` file should now look as below
 ![afterTraining](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-training.PNG)   
  </p>
</details>
<details>  
<summary><b>6. Evaluate your model</b></summary>
  <p>
    
   Your data is in the right shape, an algorithm has been chosen, and your model is ready to be trained. Great job so far!
   Let's take a look at how accurate the model you've created is. 
   
   Evaluating your model is a two step process:
   1. Transforming your test dataset using the trained model
   2. Calculating metrics based on probabilities of the predicted values and the true values
   
To transform our test data using the trained model, simply call the `.Transform` method on the trained model, passing in the test dataset as an argument.</br>
Add the below line of code to your `Program.cs` file
   
    var predictions = trainedModel.Transform(testTrainData.TestSet);
    
To calculate the evaluation metrics for our model, use the `BinaryClassification` evaluator on the `MLContext`.
Add the below line of code to your `Program.cs` file
      
    var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "isFraud");

 The `Program.cs` file should now look as below
 ![afterEvaluation](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-evaluation.PNG)  

**Train our model**</br>
Put a break-point just after the most recently added line, and run the console application by hitting F5.</br>
This should take a couple of minutes depending on the power of your computer. </br>
Once at the debug statement, expand the properties to see the metrics. 

 ![aftermetrics](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-run-1.png)  
 
Wow, the accuracy is 0.9988 or more precisely **99.9%**!
Hold on a minute, can we have been so lucky to chose the right algorithm at the first try to get a nearly perfect model?

Unfortunately we are not that lucky. Accuracy alone can be a very misleading metric, especially for highly unbalanced datasets as the one we are working on.

If we look at the shape of the dataset given by the Jupyter notebook executed earlier we can see that we have 6,362,620 rows in the dataset, but only 8,213 are fraudulent. That means **99.9%** of all transactions in the dataset are non-fraudulent. Given that, if our model is just guessing non-fraudulent for all transactions it will achieve a 99.9% accuracy but miss all and any fraudulent transactions.</br> 

This is the curse of non-balanced datasets. What are some other metrics we can use together with accuracy to determine if a model truly is useful?
</br>
ML.NET provides some great documentation on [metrics](https://docs.microsoft.com/en-us/dotnet/machine-learning/resources/metrics)
For our scenario, we want to have a better measurement to determine true positives, false positives, true negatives and false negatives.

This is where to machine learning concepts, **Precision**, **Recall** and **F1 Score** comes in to play. 

- **Precision** - attempts to answer the question of how many of my positive findings are actually correct? If we only have true positives, this value will be 1
- **Recall** - attempts to answer the question of how many of actual true positives were actually correct. Recall takes in to consideration false negatives, meaning in our case fraudulent transactions that we didn't catch. If we catch all fraudulent transactions then this value will be 1 </br>
- **F1 Score** - The harmonic mean between Precision and Recall</br>

Precision and Recall are normally working against each-other, meaning that you'll have to pick what is most important for you. Would you rather flag more transactions as fraudulent even if they're not, but in that case make sure not to miss any (e.g. having many false positives) or are you willing to let some fraudulent transactions flow through with every actually flagged transaction being correct (e.g. having no false positives but some false negatives).

A good measurement for a binary classifier, especially trained on highly unbalanced dataset, is the F1 Score. In an ideal world this value **should be 1**. If we look at how our model did, we can see that **we only got a value of 0.48**, which is very low.

| Metric  | Value  | 
|:---|:--------:|
| Accuracy    | 99.9%  |
| AreaUnderPrecisionRecallCurve  | 0.75  | 
| F1Score  | 0.48  | 

Another good tool to use is the confusion matrix, which gives you a good overview of how many false positives or false negatives the model creates.

The confusion matrix  looks as follows: <br/>
Predicted values &rightarrow; <br/>
Actual values &downarrow; <br/>

|   | IsFraud  | IsNotFraud  |
|---|:--------:|:-----------:|
| IsFraud   | 650  | 1274  |
| IsNotFraud  | 155  | 635,882  |

From the confusion matrix we can see that we are getting 155 false negatives and 650 transactions were correctly labelled as fraudulent (true positives). However, we missed a total of 1274 transactions that were predicted as non-fraudulent when they actually were.

Given that our model is not fully up to the task, what can we do to improve it? To find out, please move on to the next section.

  </p>
</details>
<details>
<summary><b>7. Iterate, iterate, iterate...</b></summary>
  <p>
    
We have identified that a cause for our model not being good enough is the fact that our data is highly unbalanced. As mentioned earlier, this can be addressed by adding more transactions that are fraudulent, but that means going back and finding about 3-6 million more records that are fraudulent. Although it's possible to synthesize more data, this is most likely not a feasible way forward.
    
Fortunately, there are certain algorithms that are better than others in handling highly unbalanced data. One of those are `Decision Trees`

Decision trees are versatile Machine Learning algorithms that can perform both classification and regression tasks. Decision trees creates, as the name implies, a tree-like decision structure in which observations are captured in the tree nodes and the final decision (fraudulent or non-fraudulent) are captured in the leaves. Decision trees can either be binary or non-binary, depending on how many lower level nodes one node connects to.

To boost the overall prediction performance of decision trees, it is common to implement something called `Ensemble learning` in which multiple weak learners are trained, and from which each individual prediction is pooled together to an overall answer. For decision trees, this is called creating a forest.

Two decision tree ensemble algorithms are `FastTreeBinary` and `FastForestBinary`

Decision trees are easily to conceptually understand, and they are fairly immune to non-balanced data. However, compared to logistic regression, they do have a lot more hyper parameters to set, for example number of leaves, learning rate and so forth that makes using them and finding the optimal values a bit more complicated.

Let's take a look at the `FastTreeBinary` algorithm.

To implement the `FastTreeBinary` algorithm, substitute the line defining the trainer with the following:

    mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options 
    { 
      NumberOfLeaves = 10, 
      NumberOfTrees = 50,  
      LabelColumnName = "isFraud", 
      FeatureColumnName = "Features" 
    }));

Make sure to also add the neccessary using statement:
`using Microsoft.ML.Trainers.FastTree;`

_Note: training this model will take a longer time as we will be training 50 individual models_

The `Program.cs` file should now look as below
![aftermetrics2](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-run-2.png) 

If we again run the console application to train our model (hit F5 and set the breakpoint after the metrics variable), we will see the following result:

![aftermetrics3](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-run-3.png) 

| Metric  | Value  | 
|:---|:--------:|
| Accuracy    | 99.9%  |
| AreaUnderPrecisionRecallCurve  | 0.79  | 
| F1Score  | 0.84  | 

This is a tremendous improvement. Our F1 Score has increased to 0.84.

The confusion matrix does also look a lot better<br/>
Predicted values &rightarrow; <br/>
Actual values &downarrow; <br/>

|   | IsFraud  | IsNotFraud  |
|---|:--------:|:-----------:|
| IsFraud   | 603  | 21 |
| IsNotFraud  | 202  | 637,135  |

What do we notice? We have reduced the number of false negatives, fraudulent transactions being marked as non-fraudulent when they in fact are. We had to sacrifice some precision to do so, meaning that we have increased the number of false positives. We only missed 21 transactions that actually were fraudulent, a fantastic improvement from our earlier value of 1274.

This model can be furthered fine-tuned by altering hyper parameters such as learning curve, number of trees and so forth. We can also use techniques such as cross-validation. For our purposes this model will do just fine.

Training a model involves a lot of iterative work to end up at the most optimal solution.
A couple of common approaches to improve a model are:

- Increasing the size of the dataset
- Adding additional features with predictive power
- Creating new derived features out of existing features
- Altering the machine learning algorithm utilized
- Fine-tuning the model with different hyper parameters
- Down-sizing the dataset

  </p>
</details>
<details>
<summary><b>8. Deploy to production</b></summary>
  <p>
    
Once we are happy with our model we will need to save it for further use. ML.NET models are saved as .zip files that later can be loaded in to a prediction engine and used to run prediction in e.g. an Azure Function or ASP.NET Core application.
   
To save the model to disk, simply add the line below to your `Program.cs` file:

    mlContext.Model.Save(trainedModel, data.Schema, "MLModel.zip");

The `Program.cs` file should now look as below
![afterSave](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-after-save.PNG) 

Hit F5 one more time to train your model.</br>
The MLModel.zip file will be located in the solutions directory</br>
`C:\mldotnet-real-time-data-streaming-workshop\workspace\FraudPredictionTrainer`
  </p>
</details>

To see a complete solution, please open the [FraudPredictionTrainer.sln](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/FraudPredictionTrainer) in VS Code
</details>

#### Using AutoML (CLI/Visual Studio Extension)
To build your machine learning model using ML.NET's AutoML builder, please refer to the instructions below:

<details>
  <summary>Instructions</summary>
  </br>
Selecting the correct features, algorithms, hyper arameters and so forth is complex. There is a lot of trial and error involved until you've managed to fine-tune a model to not only have good enough accuracy but also a decent area under the precision-recall curve.</br>

To simplify, ML.NET has introduced AutoML to automatically iterate through numerous algorithms with various hyper parameters to find one that yields a good model.
</br>

To use the ML.NET CLI to automatically train a model based on our given data, to the following:

   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br>
   - In the terminal window, execute the following command to navigate to the workspace folder.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\workspace\FraudPredictionTrainer`</br>
   - Enter the below command and hit enter
```
mlnet auto-train --dataset "data.csv" --label-column-name "isFraud" --max-exploration-time 120 --has-header true --ml-task binary-classification
```

![cli](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-mldotnetcli.PNG)

For this example we are setting the max-exploration time to only 2 minutes, which is not sufficient for a data-set of this size but serves as a good example to showcase the functionality. A minimum of 1800 seconds is recommended for a data-set of this size.

AutoML is a tremendous addition to the ML.NET toolset. Not only does it create a ready to go model based on the best algorithm, but it also creates a sample application with the code used to come up with this model for further fine-tuning. 

It is also possible to use AutoML through Visual Studio. If you would like to do that, please download the Model Builder Visual Studio Extension which will give you a nice UI to work with.

<h5> Exploring the sample solution </h5>
The ML.NET CLI creates a couple of artifacts
- The MLModel.zip file containing the finished model
- A sample solution indicating how the finished model was constructed

To explore the sample application, execute the following commands in your currently open terminal window
- `cd C:\mldotnet-real-time-data-streaming-workshop\workspace\FraudPredictionTrainer\SampleBinaryClassification\SampleBinaryClassification.ConsoleApp`
- `code .`

Open the sample solution created by the AutoML CLI tool once completed (the path to the solution will be given in the terminal window).
Do you notice any differenes with the solution you created earlier?
</details>
