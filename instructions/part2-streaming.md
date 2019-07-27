# Setting up a Real-Time Data Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-automated.md) to utilize ARM templates for deployment

#### Publish the ML.NET Prediction Function
Make sure to add the following properties to the Configuration section:
- storageAccountConnection: ConnectionString to the storage account containing the ML.NET model from step 2 
- eventHubConnection: ConnectionString to the EventHubNameSpace

#### Configure and set up a Power BI Dashboard

#### Kick-off the Event Producer

## Real-Time Data Pipeline with Azure ML integration

#### Step 1: Setup an EventHub

#### Step 2: Setup an Azure Machine Learning Web Service

#### Step 4: Setup a Stream Analytics Job

#### Step 5: Setup an Egress Logic App

#### Step 6: Setup a PowerBI Dashboard0

#### Step 7: Inititate the Event Producer
