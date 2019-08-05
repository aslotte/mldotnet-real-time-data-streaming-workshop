###  Deploy Azure Infrastructure using an Azure Resource Management (ARM) Template

#### 1. Deploy ARM Templates

##### 1.1 Real-time streaming pipeline
- Navigate to [deploy an ARM template](https://portal.azure.com/#create/Microsoft.Template)
- Click **Build your own Template in the Editor**
- Copy and paste the [ARM Template](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/deploy/pipeline-with-azureml.json)
- Click "Save"
- Select to create a new resource group
- Enter the required template parameters:
    - Notification e-mail
    - Power BI user name
    - Power BI display name
- Select a location closest to you    
- Select to agree to terms and conditions and click **Purchase** to trigger the deployment.

**Please Note:** The deployment will indicate failure but this is just because it was unable to authenticate the Power BI connection which you will later have to authorize

##### 1.1 Azure Machine Learning workspace
- Follow this [link](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-quickstart-templates%2Fmaster%2F101-machine-learning-create%2Fazuredeploy.json)
- Select the previously created resource group
- Enter name for your machine learning workspace, e.g. fraudulent-transactions
- Select a location closest to you
- Select to agree to terms and conditions and click **Purchase** to trigger the deployment.

#### 2. Authenticate accounts
The ARM template will succesfully set up the required infrastructure but will require you to authenticate you Outlook and PowerBI accounts to fully function.

##### Authenticate Power BI output
- Navigate to your Azure Stream Analytics Job
- Click on the powerbi output
- Click the blue button "Renew Authorization"
- Log-in using your Power BI user account
- Click "Save"
- Navigate back to the Stream Analytics overview page
- Click "Start" to start your streaming analyticsc job

##### Authenticate Outlook notifier
- Navigate to your Azure Logic App
- Click on "Edit"
- Click on the Outlook connection step (last step)
- Click on the invalid connection symbol
- Log-in using your outlook account
- Navigate back to the Logic App overview page
- Click "Enable" to enable your trigger

#### 4. Create a Machine Learning input to Azure Stream Analytics
This step will need to be done in part 3, once a Machine Learning model have been trained and a Machine Learning Web Service have been created. 
