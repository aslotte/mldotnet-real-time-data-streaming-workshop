# Setting up a Real-Time Data Streaming Pipeline

## Introduction
In this part of the workshop, we will be setting up the real-time data pipeline in Azure. The core pipeline will be automatically provisioned using Azure Resource Management (ARM) templates. If you are interested, feel free to try to set up the entire pipeline manually using the solution architecture diagram as a guide!

## Real-Time Data Pipeline with ML.NET integration

### 0. Deploy Infrastructure Manually
<details>
  <summary>Deploy Infrastructure Manually</summary>
  <p>

**Please Note: The explicit guidance for this section is intentionally kept at a mimimum. This is so that you more effectively can sharpen you Azure skills! No need to worry if you were not able to fully set up the infrastructure manually. You can automatically set it up using the provided ARM templates in step 1.**

#### 0.1 Deploy Event Hubs </br>
- Open your [Azure Portal](https://portal.azure.com)
- Click on "Create a resource" (top-left corner)
- Search for "Event Hubs"
- Select "Event Hubs" in the returned list of results
- Click "Create"
- Enter a unique name (e.g. transaction-eh-yourname)
- Select a pricing tier
- Select an existing resource group or create a new one 
- Click "Create"

Once the deployment is complete, navigate to the Event Hub namespace you just created.
- In your Event Hub namespace, click the "+Event Hub" button in the top-middle of your screen
- Name the first Event Hub **transaction-eh**
- Click "Create"
- Again in your Event Hub namespace, click the "+Event Hub" button in the top-middle of your screen
- Name the second Event Hub **transaction-eh-enriched**
- Click "Create"

#### 0.2 Deploy Storage Account </br>
- Open your [Azure Portal](https://portal.azure.com)
- Click on "Create a resource" (top-left corner)
- Search for "Storage Account"
- Select "Storage Account" in the returned list of results
- Click "Create"
- Select an existing resource group or create a new one 
- Enter a unique name (e.g. mlmodelyourname)
- Click "Review + create"
- Click "Create"

Once the deployment is complete, navigate to the Storage Account you just created.
- In your Storage Account, click "Blobs"
- Click on the "+Container" button in the top-middle of the screen
- Name the first container **model**
- Click "OK"
- Again in your Storage Container, "+Container" button in the top-middle of the screen
- Name the second container **reference**

#### 0.3 Deploy Service Bus Queue </br>
#### 0.4 Deploy Logic App </br>
#### 0.5 Deploy Function App </br>
#### 0.6 Deploy Stream Analytics Job </br>
 
 </p>
</details>

### 1. Deploy with ARM Templates
<details>
  <summary>Deploy with ARM Templates</summary>
  <p>

**Note: This step is only required if we skipped step 0**

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
- In Azure, navigate to your storage account starting with mlmodel and select **Blobs** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
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
- In Azure, navigate to your storage account starting with mlmodel and select **Blobs** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
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
<details>
  <summary>Kick-off the Event Producer</summary>
  <p>
    
#### 5.1 How to Kick-off the Event Producer
A streaming pipeline does not do much without events to process. 
In this workshop we will utilize an artifical event producer as a real-time event source for transaction data is difficult to find.

To start the event producer, please follow the steps below.

   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br> 
   - In the terminal window, execute the following command to navigate to the folder of the solution.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\transaction-simulator\TransactionSimulator`</br> 
   - In the terminal window, execute the following command to open the folder in VS Code `code . -r`</br> 
   - Navigate to your transaction-eh event hub namespace in Azure![ehnamespace](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-event-hub-namespace.png)</br> 
   - In the menu to the left, click **Shared Access Policies**</br> 
   - Click on the **RootManagedShareAccessKey**</br> 
   - Copy the primary connection string to clipboard</br> 
![eh-keys](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/eh-access-keys.png)
   - Navigate back to VS Code</br> 
   - Open the solutions `appsettings.json` file
   ![appSettings](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-appconfig.PNG)</br> 
   - Set the parameter `EventHubConnectionString` to the copied value</br> 
   - To start sending events to the event-hub, build and run the solution by pressing F5.</br>     
  </p>  
</details>

### 6. Setup a Power BI Dashboard (optional)
<details>
  <summary>Setup a Power BI Dashboard</summary>
  <p>
    
Please follow the steps below to get started with Power BI.</br>

**Note - this step is optional and only possible to complete if you possess a work or school account. It's not possible to create a Power BI account with a @gmail or @outlook address.**

#### 6.1 Create a Power BI Account
1. Navigate to https://powerbi.com 
2. Click on **Start Free**![start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-create.PNG)
3. Follow the provided instructions

#### 6.2 Create a Power BI Output
To output data from Azure Stream Analytics, we'll need to create an output.
1. Navigate to your Stream Analytics Job in Azure
2. Stop the job if it is running
3. Click on **Outputs** ![streamAnalytics](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics.png)
4. Select to add an output and select Power BI in the list ![output](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics-add-output.png)
5. Enter **powerbi** as output name
6. Enter **fraudulent** as dataset and table name ![output1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-add-powerbi-output.PNG)
7. Click **Authorize**
8. Provide your Power BI credentials
9. Click **Save**
10. In the menu to the left, select **Query**
11. Uncomment the Power BI query ![output1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics-query.PNG)
12. Save the changes
13. Go back to **Overview** and start the Stream Analytics Job

#### 6.3 Creating a dashboard
To create a dashboard, please follow the steps below:
1. Navigate to https://app.powerbi.com/ 
2. Sign-in to your account
3. Select to create a new dashboard in the top-right corner
4. In the dashboard, select **+Add tile**. 
5. For the tile type, select **Custom Streaming Data**
![tile](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-add-tile.PNG)
6. Select the dataset the Stream Analytics job created for you, named **fraudulent**
7. Select the type of tile you would like to create and which values to display
![tile](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-add-custom-tile.PNG)

#### 6.4 Example Dashboard
![Fraudulent](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-example.PNG)
    
  </p>
</details>

### 7. Explore
Great job! With the event producer kicked off, you should start to see events flowing through your pipeline and enriched by your machine learning model. 

1. Open your Azure Event Hub and observe event flowing
2. Open your Outlook inbox to see e-mails being sent to you from your Azure Logic App, when fraudulent transactions are detected
3. Open your Power BI Dashboard to see live events flowing via you Stream Analytics job (optional)

### Set up infrastructure manually
If you are interested and would like to further sharpen your Azure skills, attempt to set up the infrastructure manually in a new resource group
