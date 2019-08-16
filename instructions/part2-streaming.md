# Setting up a Real-Time Data Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-mldotnet-automated.md) to utilize ARM templates for deployment

### Upload reference data
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-referencedata.md)
to upload reference data used to enrich the moving datastream.

### Upload the Machine Learning Model
If you have already trained your Machine Learning model, make sure to navigate to your storage account and upload the model (named MLModel.zip) in to the container named **model**.
You are also able to directly use a pre-trained model from this repo if you've decided to skip part 1, found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/model)

### Publish the ML.NET Prediction Function
Please follow the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-azure-function.md) to publish the prediction function to Azure

## Real-Time Data Pipeline with Azure ML integration

### Deploy with ARM Templates
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-azureml.md) to utilize ARM templates for deployment

## Kick-off the Event Producer
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-kickoff-event-producer.md) to kick-off the event producer.


## Set up infrastructure manually
If you are interested and would like to further sharpen your Azure skills, attempt to set up the infrastructure manually in a new resource group
