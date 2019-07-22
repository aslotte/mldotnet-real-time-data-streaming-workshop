# Setting up a Real-Time Data Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure.
If you're comfortable setting up the pipeline manually, please follow the instructions below. This is recommended as it will provide useful Azure experience. If any of the steps do not properly work, or if you would like to automatically set up the pipeline for any reason, please resort to the Azure Resource Management Templates (ARM) in this repo.

## Real-Time Data Pipeline with ML.NET integration

### Step 1. Deploy Azure Resource Management Template
To deploy the core Azure infrastructure, please follow the link below:

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fgithub.com%2Faslotte%2Fmldotnet-real-time-data-streaming-workshop%2Fblob%2Fmaster%2Fsrc%2Freal-time-data-streaming%2Fdeploy%2Fpipeline-with-mldotnet.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/> 
</a>

### Step 1: Setup an EventHub
- Create a new Event Hub Namespace
- Within the namespace, create two new eventhubs named
  - transaction-eh
  - transaction-enriched-eh

### Step 2: Create an storage account to store ML.NET model

### Step 3: Setup an Azure Function

### Step 3a: Publish the ML.NET Azure Function
Make sure to add the following properties to the Configuration section:
- storageAccountConnection: ConnectionString to the storage account containing the ML.NET model from step 2 
- eventHubConnection: ConnectionString to the EventHubNameSpace

### Step 4: Setup an Egress Service Bus Queue 

### Step 5: Setup a Stream Analytics Job

### Step 6: Setup an Egress Logic App
#### Email settings
- To: json(base64toString(triggerBody()['ContentData']))['email']
- Body: "A Fraudulent Transaction was discovered, your account has been locked. The transactions was of type @{json(base64toString(triggerBody()['ContentData']))['Type']}  originating from @{json(base64toString(triggerBody()['ContentData']))['NameDest']}",

### Step 7: Setup a PowerBI Dashboard

### Step 8: Inititate the Event Producer


## Real-Time Data Pipeline with Azure ML integration

### Step 1: Setup an EventHub

### Step 2: Setup an Azure Machine Learning Web Service

### Step 4: Setup a Stream Analytics Job

### Step 5: Setup an Egress Logic App

### Step 6: Setup a PowerBI Dashboard

### Step 7: Inititate the Event Producer





1. Create an Event Hub namespace
2. Create an Event Hub
3. Create a Logic App
4. Open the Logic app designer and select to listen to a Twitter feed
5. Authenticate yourself towards Twitter
6. Add a new step, with sending the events to our Event Hub
7. Add a ContentParameter with value triggerBody()
8. Open VS - create a Azure Stream Analytics job, add input, add SQL, remember output time
