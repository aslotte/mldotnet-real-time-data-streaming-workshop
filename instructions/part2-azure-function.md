## Publish Azure Function to Predict Fraudulant Transactions
All incoming transactions get evaluated to determine if they are fraudulant or not based on our traine ML.NET Machine Learning Model.
This prediction occurs in an Azure Function that we will go ahead and deploy.

### Prerequisites
- Visual Studio 2017/2019 or Visual Studio code with Azure Toolkit and Azure Function's extensions

### Deploy
To deploy the Azure Function, please follow the steps listed below:

#### 1. Clone source code
Please clone this repository locally using for example a Git command prompt or Github Desktop.
Open the FraudPredictionFunction solution [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/real-time-data-streaming/fraud-prediction-function)

#### 2. Build solution and Publish to Azure
Build the solution and publish the function to your new Function App.

To publish the function:

1. Right click on the solution and select "Publish"
![Publish](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/publish-function-1.png)

2. Check the radio button "Select Existing" and check "Run from Package File". Click Next.
![Selections](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/publish-function-2.png)

3. Select your Azure Subscription and navigate to your Function app. Select and click ok
![Subscription](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/publish-function-3.png)

4. Click "Publish"

