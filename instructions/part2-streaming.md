# Setting up a Real-Time Data Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-automated.md) to utilize ARM templates for deployment

### Upload reference data
The real-time pipeline utilizes reference data to enrich the stream. In this particular case we will be enriching the stream with information about where to send an notification e-mail in case the model detects a fraudulant transaction. Please navigate to your storage account and upload the [reference-data.json](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/stream-analytics/reference-data.json) file in to the container named "reference"

Extract of file:

```  
[
    {
        "customerid": "C1305486145",
        "email": "alexander.slotte.demo@outlook.com"
    },
    ....
```

### Upload Machine Learning Model
If you have already trained your Machine Learning model, make sure to navigate to your storage account and upload the model (named MLModel.zip) in to the model container.

### Publish the ML.NET Prediction Function

#### Configure and set up a Power BI Dashboard

#### Kick-off the Event Producer

## Real-Time Data Pipeline with Azure ML integration

#### Step 1: Setup an EventHub

#### Step 2: Setup an Azure Machine Learning Web Service

#### Step 4: Setup a Stream Analytics Job

#### Step 5: Setup an Egress Logic App

#### Step 6: Setup a PowerBI Dashboard0

#### Step 7: Inititate the Event Producer
