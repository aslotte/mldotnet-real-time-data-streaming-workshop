## Training your model in ML.NET
So you're ready to start creating your Machine Learning model with ML.NET? Awesome!
ML.NET is an open-source, cross-platform library, released to the public in preview during MS Build 2018 and for at MS Build 2019.
It bridges the gap between Software Developers and Data Scientists and allows .NET Developers to make their applications smarter.

The general steps for training your model are the same regardless if you are training your model using ML.NET or a Python based library such as Scikit Learn. To train your model in ML.NET, please expand and follow the instructions below:

<details>
<summary>1. Determine your problem domain</summary>
  <p>

Framing and narrowing down on the actual business problem you are attempting to solve is key for a successful Machine Learning model. A lot of the times people attempt to start with a cool algorithm or the data they have, but without a clear understanding of the problem they are trying to solve, and the dialog with Subject Matter Experts (SME's), crucial data may be overlooked and business value may not be provided. In this example, we would like to secure the banks transfers and transactions such that fraudulent activity can be avoided.
  </p>
</details>
<details>
  <summary>2. Gather and load your data</summary>
    <p>
      
Once the business problem has been determined, it's time to gather your data. In a real-world example, data is normally gathered from multiple data-sources (both public and private), aggregated and pivoted in to a workable shape. For our purposes, the data we will be using can be retrieved from [Kaggle](https://www.kaggle.com/ntnu-testimon/paysim1). 
      
Other available data-sources worth exploring are: 
    - [Google Public Datasets](https://cloud.google.com/public-datasets/)  
    - [AWS Open Data](https://aws.amazon.com/opendata/)  
    - [Open Government Data](https://www.data.gov/)  
    - [EU Open Data](https://data.europa.eu/euodp/en/data)  
   
  <details>
    <summary>2.1 Explore the dataset</summary>
   <p>
     
   - Download the dataset from Kaggle and extract the content<br/>
   - Familiarize yourself with the available features (columns)<br/>
   - Which columns are your features and which is your label (what you would like to predict)?<br/>
   - Is the dataset balanced? (hint: what's the distribution of fraudulent and non-fraudulent transactions)<br/>
   - What's the data type of the available features?<br/>
   - Does any of the columns have missing values?<br/>
   - Does any of the columns contain outliers?<br/>
   
   Exploring a large dataset can be a daunting task. Loading a dataset containing 6+ million rows in something like Excel is not always feasible due to application limitations and performance. To make life easier for us we can use an open-source Python library called **Pandas** in e.g. a Jupyter notebook.
   
   To explore the dataset using Pandas and a Jupyter notebook:
   - Navigate to the [Kaggle dataset](https://www.kaggle.com/ntnu-testimon/paysim1) and click "New Kernel". 
   - When selecting Kernel type, select "Notebook"
   - In the top-left corner, select File -> Upload Notebook
   - Upload the [Jupyter notebook](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/machine-learning/jupyter/fraudulent-transactions-jupyter-notebook.ipynb) in this repo
   - Select Run -> Run all
   - Explore the results
   
   </p>
  </details>
  <details>
    <summary>2.2 Getting started with ML.NET</summary>
    <p>
      
   Fantastic, you have gathered the required data and are now ready to dive in to ML.NET. ML.NET is distributed as a NuGet package and can be included in your solution like any other package. 
   
   To get started:
   - Create a new .NET Core v2+ console application
   - Right-click on the solution and select to "Manage NuGet Packages for Solution"
   - Search for and install the following NuGet package<br/> 
    - Microsoft.ML<br/> 
    - Microsoft.ML.FastTree<br/>
    - Microsoft.ML.LightGmb<br/>
   - Right click on the solution once again and select "Add -> Existing Item..."
   - In the file explorer window, select to view all items in the bottom right corner
   - Rename your comma-separated file containing your data to "data.csv" and select to add this as an existing item 
   - Right-click on you newly added file and select "Properties". Change to "Copy if Newer"
   
   The steps above ensures you have the correct dependencies installed and your data is ready to be worked on.
   Before we jump in to the code, let me introduce two concepts of ML.NET that we will be depending on a fair amount, **pipelines** and a **MLContext**. 
   
   Everything in ML.NET originates from an **MLContext**. The MLContext contains all the data loaders, transformers, algorithms, evaulation tools and so forth. 
   **Pipelines** is a concept heavily utilized in ML.NET, which just means that we will be creating an initial instance to which we will append operations, such as data transformations, training algorithm and so forth. 
   
   To get started, let's create an MLContext. 
   
   ```
    var mlContext = new MLContext(seed: 1)
   ```
   
   Setting the property seed to 1 ensures deterministic randomness in operations such as splitting test/train data, which is normally desired.    
   </p>
  </details>
  <details>
    <summary>2.3 Load your data in ML.NET</summary>
    <p>

If you take a look at the DataCatalog of the MLContext (F12 in the the class) you'll notice a number of ways you can load your data in to memory. Just to mention a couple, we can load data from binary, from file, from a SQL database and so forth. In this example, we will be loading our data from our comma-separated file. To do this, let's start by defining where the file resides. 
   
   Add a static member variable:
   
   ```
    private static string DataPath = "data.csv";
   ```        
   
To succesfully load our data, we need to tell ML.NET what the schema of our data looks like. Just as this is done in Entity Framework, we can do this by creating a simple POCO, with a property for each column in the dataset. Try to do this yourself by creating a class called "Transaction". 
   
Make sure to decorate each property with ColumnName and LoadColumn, where ColumnName defines the name of the column as it reads in the csv file and LoadColumn defines the index of the column.
   
   ```
    [ColumnName("step"), LoadColumn(0)]
   ```

Furthermore, the machine learning algorithms can only work on number data of type floats. Thus make sure each property containing a number is of type float.

Did you have a try? Perfect! 
<details>
  <summary>2.3.a Here's a a complete solution to validate against.</summary>
  <p>
   
    
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
   
  </p>
</details>
  
   Once you've defined the schema, you're ready to load the data in to memory. 
   To do this, simply add the following:
   
      var data = mlContext.Data.LoadFromTextFile<Transaction>(DataPath, hasHeader: true, separatorChar: ',');
      
  The LoadFromTextFile defines the schema as a generic. To the method you'll also have to supply the path to the data, if the data contains headers or not as well as how the data is separated. In our scenario that will be comma-separated.
 </p>
</details>
</p>
</details>
<details>
<summary>3. Split your data in a test and training set</summary>
  <p>
    
A cruicial part of training a machine learning model is to be able to evaluate its performance on data not utilized when training the model. Thus, before starting to train our model, we want to make sure we put a portion of the data aside for evaluation purposes.

ML.NET features built-in functionality to perform a random split of the data in to a training and test set. 

      var testTrainData = mlContext.Data.TrainTestSplit(data);
      
Note that splitting your data in to a train and test set is strictly not always required. A technique called cross-validation can also be utilized to achieve the same result (which normally results in a better final model). We will explore this concept later on in this workshop.  

  </p>
</details>
<details>
<summary>4. Transform your data</summary>
  <p>
    
The dataset from Kaggle is in an overall great condition, as opposed to how it could look. The variables are neatly contained in columns, thus no pivoting of the data is needed. The data contains no missing values that needs to be replaced.
   
Machine Learning models are very picky in terms of data quality, so making sure that the data is top-notch is critial. We want to make sure that no columns have missing values, that the data is reasonable balanced and that no obvious outliers exists. The only main-concern we have with our data is that it is highly unbalanced. The number of fraudulent transactions to train the data on is just a couple of percents of the total dataset. If we were able to, we would idealy include additional fraudulent transactions to balance the data, but as this is not possible we will apply other techniques to counter this in a later step.

As mentioned when loading the data in to memory, machine learning algorithms function based on numerical data, and has a difficult time working with e.g. strings. Our dataset currently contains three features that contains text, **type**, **nameOrig** and **nameDest**.
To transform this features to float vectors, we can use a technique called **OneHotEncoding** which will create new binary columns for each value present in a feature space. For example, the type column contains values such as "Payment" and "Transfer". If we apply OneHotEncoding on the type column, ML.NET will create new columns, e.g. IsPayment, IsTransfer with a binary response, either 1 or 0 to define what the type is. This approach greatly increases the performance of the algorithm and allows is to converge to an optimal solution.

To perform OneHotEncoding on the type column, you can call the OneHotEncoding method located in the Transforms catalog of ML.NET as such:

    mlContext.Transforms.Categorical.OneHotEncoding("type")
    
 At this point, this is very pipelines come in to play. As we will have multiple transformation operations we would like to conduct, we can chain them all together in to a data processing pipeline:
 
    var dataProcessingPipeline = mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameOrig"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameDest"))
                
 Perfect. Our non-numeric features are now transformed in to a form the algorithm can understand.
 So which features do you think account for the variance in the dataset? Or put in another way, which features do you think are relavent  to include in your model? Feature engineering is a difficult topic. It's very likely that additional features may be needed to achieve a better model, or dervied features of the existing feature set may yield a better outcome. This is where it is very important to consult with a subject matter expert to understand the problem domain you're in and what data may be relavent. For our purposes, we can start off my trying to include all columns in our model, as we only have seven or so features (you may have thousends if not more in real-world example). 
 
 To define which features are relavent for the model to know about, we will have to concatenate them in to a feature vector
 This can be done as such:
 
       mlContext.Transforms.Concatenate("Features", "type", "nameOrig", "nameDest", "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest")
       
 To put it all together, your data processing pipeline will look like this:
 
             var dataProcessingPipeline = mlContext.Transforms.Categorical.OneHotEncoding("type")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameOrig"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("nameDest"))
                .Append(mlContext.Transforms.Concatenate("Features", "type", "nameOrig", "nameDest", "amount", "oldbalanceOrg", "oldbalanceDest", "newbalanceOrig", "newbalanceDest")
 
  </p>
</details>
<details>
<summary>5. Train your model</summary>
  <p>
    
 Once we have created our data processing pipeline it's time to select the trainer (algorithm) to use. 
 
 The most common types of algorithms to use are:
    
   - Linear Regression <br/>
   - Nearest Neighbor <br/>
   - Naive Bayes <br/>
   - Decision Trees <br/>
   - Support Vector Machines (SVM) <br/>
   
   Each family of algorithms has its pros and cons as we will see later in this workshop, but for simplicities sake, lets start off with the most straightforward algorithm, linear regression. A variant of linear regression is logistic regression. 
   So where do you find the trainers in ML.NET? 
   The trainers are located under the given ML Task we are trying to perform. In our case we are attempting to do something called **BinaryClassification**, which is to predict one out of two possible values (thus binary). Other common ML tasks are Multi-Class Classification (three or more values), regression, clustering, anomaly detection and so forth.
   
   We can create a training pipeline using logistic linear regression as follows:
   
    var trainingPipeline =dataProcessingPipeline
        .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "isFraud"));
   
   _Note that we append the trainer to the data processing pipeline, as well as define which column we are trying to predict. Often called the label column._
   
  Once the trainer has been appended, all that remains is to using the trainingPipeline to a fit an as accurate model as possible based on the training dataset. To do this, we will use the `.Fit` method on the IEstimator interface

    var trainedModel = trainingPipeline.Fit(testTrainData.TrainSet);
  
  _Note that we are using only the training dataset to train our model_
    
  </p>
</details>
<details>  
<summary>6. Evaluate your model</summary>
  <p>
    
   Your data is in the right shape, an algorithm has been chosen and your model has been trained. Great job so far!
   Let's take a look at how accurate the model you've created is. 
   
   Evaluating your model is a two step process:
   1. Transforming your test dataset using the trained model
   2. Calculating metrics based on predicted value (in this case, if our model predicted a fraudulent transaction or not) and actual value
   
To transform your test data using the trained model, simply call the `.Transform` method on the trained model, passing in the test dataset
   
    var predictions = trainedModel.Transform(testTrainData.TestSet);
    
To calculate the metrics we will be using to benchmark our model, use the BinaryClassification evaluator on the MLContext:
      
    var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "isFraud");
      
Let's put a break-point at this most recently added line and run the console application.
This should take about 2-5 min depending on the power of your computer. Once at debug statement, expand the properties to see the metrics. 

Wow, the accurary is 0.9988 or more precisly **99.9%**!
Hold on a minute, can we have been so lucky to chose the right algorithm at the first try to get a nearly pefect model?

Unfortunately we are not that lucky. Accuary alone can be a very misleading metric, especially for highly unbalanced datasets as the one we are working on.

If we look at the shape of the dataset given by the Jupyter notebook executed earlier we can see that we have 6,362,620 rows in the dataset, but only 8,213 are fradulent. That means **99.9%** of all transactions in the dataset are non-fraudulent. Given that, if our model is just guessing non-fradulent for all transactions it will achieve a 99.9% accuracy but miss all and any fradulent transactions. 
This is the curse of non-balanced datasets. What are some other metrics we can use together with accuracy to determine if a model truely is useful?

ML.NET provides some great documentation on [metrics](https://docs.microsoft.com/en-us/dotnet/machine-learning/resources/metrics)
For our scenario, we want to have a better measurement to determine true positives, false positives, true negatives and false negatives.

This is where to machine learning concepts, **Precision** and **Recall** comes in to play. 

- **Precision** - attempts to answer the question of how many of my positive findings are actually correct? If we only have true positives, this value will be 1
- **Recall** - attempts to answer the question of how many of actual true positives were actually correct. Recall takes in to consideration false negatives, meaning in our case fraudulent transactions that we didn't catch. If we catch all fradulent transactions then this value will be 1

Precision and Recall are normally working against each-other, meaning that you'll have to pick what is most important for you. Would you rather flag more transactions as fraudulent even if they're not, but in that case make sure not to miss any (e.g. having many false positives) or are you willing to let some fradulent transactions flow through with every actually flagged transaction being correct (e.g. having no false positives but some false negatives).

A good measurement to determine how good a classifier is, is to look at the area under the precision-recall curve. In an ideal world this value **should be 1**. If we look at how our model did, we can see that **we only got a 0.31** value which is very low.

Another good tool to use is the confusion matrix, which gives you a good overview of how many false positives or false negatives the model creates.

The confusion matrix for our model looks as follows:

|   | IsFraud  | IsNotFraud  |
|---|:--------:|:-----------:|
| IsFraud   | 84  | 721  |
| IsNotFraud  | 2  | 637,154  |


From the confusion matrix we can see that we are getting 721 false negatives and only 84 transactions were correctly labelled as fraudlent (true positives)

Given that our model is not up for the task, what can we do to improve it? Lets move on to the next section.

  </p>
</details>
<details>
<summary>7. Iterate, iterate, iterate...</summary>
  <p>
    
We have identified that a cause for our model not being good enough is the fact that our data is highly unbalanced. As mentioned earlier, this can be addresed by adding more transactions that are fraudulant, but that means going back and finding about 3-6 million more records that are fraudulent. This is most likely not a feasible way forward.
    
Fortunaly, there are certain algorithms that are better than others in handling highly unbalanced data. One of those are **Decision Trees**

Decision trees are versatile Machine Learning algorithms that can perform both classification as well as regression tasks. Decision trees creates, as the name implies, a tree-like decision structure in which observations are captured in the tree nodes and the final decision (fraudulent or non-fradulent) are captured in the leaves. Decision trees can either be binary or non-binary, depending on how many lower level nodes one node connects to.

To boost the overall prediction performance of decision trees, it is common to implement something called **Ensemble learning** in which multiple weak learners are trained, from which each individual prediction is pooled together to an overall answer. For decision trees, this is called creating a forest.

To decision tree ensemble algorithms are **FastTreeBinary** and **FastForestBinary**

Decision trees are easily to conceptually understand, and they fairly immune to non-balanced data. However, compared to logistic regression, they do have a lot more **hyperparameters** to set, e.g. number of leaves, learning rate and so forth that makes using them and finding the optimal values a bit more complicated.

Lets take a look at the FastTreeBinary algorithm.

To implement the FastTreeBinary algorithm, substitute the line defining the trainer with the following:

    mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options 
    { 
      NumberOfLeaves = 10, 
      NumberOfTrees = 50,  
      LabelColumnName = "isFraud", 
      FeatureColumnName = "Features" 
    }));

_Note: training this model will take a longer time as we will be training 50 individual models_

If we again run the console application to train our model, we will see the following result:

| Metric  | Value  | 
|:---|:--------:|
| **Accuracy**    | 99.9%  |
| **AreaUnderPrecisionRecallCurve**  | 0.86  | 

This is a tremendous improvement. Our area under the precision-recall curve is up to 0.86. This model can be further fine-tuned by altering hyperparameters such as learning curve, number of trees and so forth. For our purposes this model will due just fine.

  </p>
</details>
<details>
<summary>8. Deploy to production</summary>
  <p>
    
   - Save the ML Model to a zip file
   - Copy the ML Model to the storage account?
    
  </p>
</details>

