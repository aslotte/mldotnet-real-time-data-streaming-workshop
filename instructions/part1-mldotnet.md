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
      
Once the business problem has been determined, it's time to gather your data. In a real-world example, data is normally gathered from multiple data sources (both public and private), aggregated and pivoted in to a workable shape. For our purposes, the data we will be using can be retrieved from [Kaggle](https://www.kaggle.com/ntnu-testimon/paysim1). There are however tons of other great free public data sources available. 
      
I encourage you to explore the following free open-data sources:  
    - [Google Public Datasets](https://cloud.google.com/public-datasets/)  
    - [AWS Open Data](https://aws.amazon.com/opendata/)  
    - [Open Government Data](https://www.data.gov/)  
    - [EU Open Data](https://data.europa.eu/euodp/en/data)  
   
  <details>
    <summary>2.1 Explore the dataset</summary>
   <p>
    - Download the dataset from Kaggle and extract the content  
    - Familiarize yourself with the available features (columns)  
    - Which columns are your features and which is your label (what you would like to predict)?  
    - Is the dataset balanced? (hint: what's the distribution of fraudulant and non-fraudulant transactions)  
    - What's the data type of the available features?  
   </p>
  </details>
  <details>
    <summary>2.2 Getting started with ML.NET</summary>
    <p>
    
   </p>
  </details>
  <details>
    <summary>2.3 Load your data in ML.NET</summary>
    <p></p>
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

