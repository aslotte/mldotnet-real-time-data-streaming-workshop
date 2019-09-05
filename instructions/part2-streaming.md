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
You can either upload your trained model to Azure, or you can use a pre-trained model found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/model)

To upload the model:
- In Azure, navigate to your storage account starting with mlmodel and select **Blob** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
- Select the container named **model**
- Click on **Upload** and browse to, and upload the `MLModel.zip` file. ![upload](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-upload.png)

### 4. Publish the ML.NET Prediction Function
Please follow the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-azure-function.md) to publish the prediction function to Azure

### 5. Kick-off the Event Producer
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-kickoff-event-producer.md) to kick-off the event producer.

### 6. Setup Power BI Dashboard (optional)
Please refer to the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-powerbi.md) to set up a Power BI dashboard and Power BI output if desired.</br>
**Note that you will need a work or school account to create a Power BI account.**

### 7. Explore
Great job! With the event producer kicked off, you should start to see events flowing through your pipeline and enriched by your machine learning model. 

1. Open your Azure Event Hub and observe event flowing
2. Open your Outlook inbox to see e-mails being sent to you from your Azure Logic App, when fraudulent transactions are detected
3. Open your Power BI Dashboard to see live events flowing via you Stream Analytics job (optional)

### Set up infrastructure manually
If you are interested and would like to further sharpen your Azure skills, attempt to set up the infrastructure manually in a new resource group
