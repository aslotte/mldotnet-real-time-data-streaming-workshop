## Training your model in ML.NET
So you're ready to start creating your Machine Learning model with ML.NET? Awesome!
ML.NET is an open-source, cross-platfrom library, relased to the public in preview during MS Build 2018 and for at MS Build 2019.
It bridges the gap between Software Developers and Data Scientists and allows .NET Developers to make their applications smarter.

The general steps for training your model are the same regardless if you are training your model using ML.NET or a Python based library such as ScikitLearn. To train your model in ML.NET, please expand and follow the instructions below:


<details>
<summary>1. Determine your problem domain</summary>
  <p>

Framing and narrowing down on the actual business problem you are attempting to solve is key for a succesful Machine Learning model. A lot of the times people attempt to start with a cool algorithm or the data they have, but without a clear understanding of the problem they are trying to solve, and the dialog with Subject Matter Experts (SME's), crucial data may be overlooked and business value may not be provided. In this example, we would like to secure the banks transfers and transactions such that fraudulant activity can be avoided.
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
   - Is the dataset balanced? (hint: what's the distribution of fraudulant and non-fraudulant transactions)<br/>
   - What's the data type of the available features?<br/>
   </p>
  </details>
  <details>
    <summary>2.2 Getting started with ML.NET</summary>
    <p>
      
   Fantastic, you have gathered the required data and are now ready to dive in to ML.NET. ML.NET is distributed as a NuGet package and can be included in your solution like any other package. 
   
   To get started:
   - Create a new .NET Core v2+ console application
   - Right-click on the solution and select to "Manage NuGet Packages for Solution"
   - Search for Microsoft.ML and install the latest version
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
  
 </p>
</details>
</p>
</details>
<details>
<summary>3. Split your data in a test and training set</summary>
  <p>
  </p>
</details>
<details>
<summary>4. Transform your data</summary>
  <p>
  </p>
</details>
<details>
<summary>5. Train your model</summary>
  <p>
  </p>
</details>
<details>  
<summary>6. Evaluate your model</summary>
  <p>
  </p>
</details>
<details>
<summary>7. Deploy to production</summary>
  <p>
  </p>
</details>

