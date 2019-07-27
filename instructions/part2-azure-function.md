## Publishing Azure Function to Predict Fraudulant Transactions
All incoming transactions get evaluated to determine if they are fraudulant or not based on our traine ML.NET Machine Learning Model.
This prediction occurs in an Azure Function that we will go ahead and deploy.

### Deploy
To deploy the Azure Function, please follow the steps listed below:

#### 1. Clone source code
Please clone this repository locally using for example a Git command prompt or Github Desktop.
Open the FraudPredictionFunction solution [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/real-time-data-streaming/fraud-prediction-function)

#### 2. Build solution and Publish to Azure
Build the solution and publish the function to your new Function App.
To publish the function:

