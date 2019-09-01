###  Deploy Azure Infrastructure using an Azure Resource Management (ARM) Template

#### 1. Deploy ARM Template
- Navigate to [deploy an ARM template](https://portal.azure.com/#create/Microsoft.Template)
- Click on "Build your own Template in the Editor"
- Copy and paste the [ARM Template](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/deploy/pipeline-with-mldotnet.json)
- Click "Save"

#### 2. Enter valid parameter values
- Select to create a new resource group, or utilize an existing.
- Enter the required template parameters:
    - Notification e-mail

#### 3. Deploy
Select to agree with terms and conditions and click "Purchase" to trigger the deployment.

#### 4. Authenticate accounts
The ARM template will succesfully set up the required infrastructure but will require you to authenticate you Outlook account to fully function.

**Authenticate Outlook notifier**
- Navigate to your Azure Logic App
- Click on "Edit"
- Click on the Outlook connection step (last step)
- Click on the invalid connection symbol
- Log-in using your outlook account
- Navigate back to the Logic App overview page
- Click "Enable" to enable your trigger
