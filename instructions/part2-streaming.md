# Setting up a Real-Time Data Streaming Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### 1. Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-mldotnet-automated.md) to utilize ARM templates for deployment

### 2. Upload reference data
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-referencedata.md)
to upload reference data used to enrich the moving datastream.

### 3. Upload the Machine Learning Model
If you have already trained your Machine Learning model, make sure to navigate to your storage account and upload the model (named MLModel.zip) in to the container named **model**.
You are also able to directly use a pre-trained model from this repo if you've decided to skip part 1, found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/model)

### 4. Publish the ML.NET Prediction Function
Please follow the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-azure-function.md) to publish the prediction function to Azure

### 5. Kick-off the Event Producer
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-kickoff-event-producer.md) to kick-off the event producer.

### 6. Setup Power BI Dashboard (optional)
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-powerbi.md) to set up a Power BI dashboard and Power BI output if desired.
**Note that you will need a work or school account to create a Power BI account.**

### 7. Explore
Great job. With the event producer kicked off, you should start to see events flowing through your pipelines and being enriched by your machine learning model. 

1. Open your Azure Event Hub and notice that events are being recivied 
2. Open your Power BI Dashboard see a live feed of events, aggregated from your Stream Analytics Jobs
3. Open your Outlook inbox to see e-mails being sent from you Azure Logic App when fraudulent transactions are detected

**Please continue with Part 3 from this point**

## Real-Time Data Pipeline with Azure ML integration

### 1. Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-azureml.md) to utilize ARM templates for deployment

### 2. Complete Part 3
Please complete [Part 3](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part1-azureml.md) of this tutorial before moving on.

### 3. Kick-off the Event Producer
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-kickoff-event-producer.md) to kick-off the event producer.

### 4. Setup Power BI Dashboard (optional)
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-powerbi.md) to set up a Power BI dashboard and Power BI output if desired.
**Note that you will need a work or school account to create a Power BI account.**

## Set up infrastructure manually
If you are interested and would like to further sharpen your Azure skills, attempt to set up the infrastructure manually in a new resource group
