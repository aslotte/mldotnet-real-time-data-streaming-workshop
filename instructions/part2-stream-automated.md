###  Deploy Azure Infrastructure using an Azure Resource Management (ARM) Template

#### 1. Deploy ARM Template
- Navigate to [deploy an ARM template](https://portal.azure.com/#create/Microsoft.Template)
- Click on "Build your own Template in the Editor"
- Copy and paste the [Raspberry PI ARM Template](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/deploy/pipeline-with-mldotnet.json)
- Click "Save"

#### 2. Enter valid parameter values
- Select to create a new resource group, or utilize an existing.
- Enter the required template parameters:
    - Notification e-mail
    - Power BI user name
    - Power BI display name

#### 3. Deploy
Select to agree with terms and conditions and click "Purchase" to trigger the deployment.


**Note: The deployment will indicate failure but this is just because it was unable to authenticate the Power BI connection which you will later have to authorize**


#### 4. Authenticate accounts
The ARM template will succesfully set up the required infrastructure but will require you to authenticate you Outlook and PowerBI accounts to fully function.

1. Authenticate Power BI output
- Navigate to your Azure Stream Analytics Job
- Click on the powerbi output
- Click the blue button "Renew Authorization"
- Log-in using your Power BI user account
- Click "Save"
- Navigate back to the Stream Analytics overview page
- Click "Start" to start your streaming analyticsc job

2. Authenticate Outlook notifier
- Navigate to your Azure Logic App
- Click on "Edit"
- Click on the Outlook connection step (last step)
- Click on the invalid connection symbol
- Log-in using your outlook account
- Navigate back to the Logic App overview page
- Click "Enable" to enable your trigger

#### 5. Upload resources to Storage account

##### Upload Machine Learning Model
If you have already trained your Machine Learning model, make sure to navigate to your storage account and upload the model (named MLModel.zip) in to the model container.

##### Reference data 
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

#### 6. Deploy Azure Function

### Final touches
- Navigate to your mlmodel storage account - upload reference-data.json and MLModel.zip
- Publish Azure Function - set additional configuration parameters
