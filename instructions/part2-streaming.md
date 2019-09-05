# Setting up a Real-Time Data Streaming Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### 1. Deploy with ARM Templates
<details>
  <summary>Deploy with ARM Templates</summary>
  <p>

#### 1.1 Deploy ARM Template
- Navigate to [deploy an ARM template](https://portal.azure.com/#create/Microsoft.Template)
- Click on **Build your own Template in the Editor** ![editor](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-custom-deploy.PNG) </br>
- Copy and paste the [ARM Template](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/deploy/pipeline-with-mldotnet.json)
- Click **Save**

#### 1.2 Enter valid parameter values
- Select to create a new resource group and enter a name
- Enter a notification e-mail to be used (needs to be an Outlook or Office365 e-mail)
![final](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-custom-deploy-final.PNG) </br>

#### 1.3. Deploy
Select to agree with terms and conditions and click **Purchase** to trigger the deployment.
The deployment will take about 3-5 minutes to complete.
</br>
#### 1.4. Authenticate accounts
The ARM template will successfully set up the required infrastructure, but it will require you to authenticate your Outlook credentials manually.

##### 1.4.1 Authenticate Outlook Notifier 
- Navigate to your Azure Logic App (fraudulent-notifier)
- Click on **Edit** ![logic app](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-edit-logic-app.png) </br>
- Click on the Outlook connection step and then the invalid connection symbol ![invalidconnection](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-invalid-outlook.png) </br>
- Log-in with your credentials
- Navigate back to the Logic App overview page
- Click **Enable** to enable your trigger (if not already enabled)    
  </p>
</details>

### 2. Upload reference data
<details>
  <summary>Upload reference data</summary>
  <p>
    
#### 2.1 Upload reference data
The real-time pipeline utilizes reference data to enrich the stream. 
In this particular case we will be enriching the stream with information about where to send an notification e-mail in case the model detects a fraudulant transaction.

To upload the reference data, please do the following:
- In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br>
- In the terminal window, execute the following command to open the `reference-data.json` file </br> 
`code C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\stream-analytics\reference-data.json`![refData](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-reference-data.PNG)
- In `reference-data.json`, do a "Find All" and replace the current e-mail with the one you would like to get notifications too.
- In Azure, navigate to your storage account starting with mlmodel and select **Blob** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
- Select the container named **reference**
- Click on **Upload** and browse to, and upload the `reference-data.json` file. ![upload](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-upload.png)

  </p>
</details>

### 3. Upload the Machine Learning Model

<details>
  <summary>Upload the Machine Learning Model</summary>
  <p>
    
You can either upload your previously trained model or a pre-trained model found [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/machine-learning/model) to Azure.

To upload the model:
- In Azure, navigate to your storage account starting with mlmodel and select **Blob** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
- Select the container named **model**
- Click on **Upload** and browse to, and upload the `MLModel.zip` file. ![upload](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-upload.png)

</p>
</details>

### 4. Publish the ML.NET Prediction Function
<details>
  <summary>Publish the ML.NET Prediction Function</summary>
  <p>
   
All incoming transactions gets evaluated to determine if they are fraudulent or not, based on our trained Machine Learning Model.
This prediction occurs in an Azure Function that needs to get deployed to Azure.

To deploy the Azure Function from VS Code, please follow the steps listed below:

   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br> 
   - In the terminal window, execute the following command to navigate to the folder of the solution.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\fraud-prediction-function`
   - In the terminal window, execute the following command to open the folder in VS Code `code . -r`
   - In the menu to the left, select the Azure symbol (at the bottom-left of the menu)
   - Click **Sign-in to Azure** and sign in with your Azure credentials </br>
   - In the top left, click on the up-arrow to **Deploy to Function App**
![deployToAzure](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/publish-function-vs-code-publish.png)
   - Select your Azure Subscription
   - Select your created Function App
   - If asked to update the Function App's run-time, select **Yes**
   - When asked if you're sure that you want to deploy the Function App, select **Yes**
   ![deploymentConfirm](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-deploy-function-confirm.PNG)
   
  </p>
</details>

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
