###  Deploy Azure Infrastructure using an Azure Resource Management (ARM) Template

#### 1. Deploy ARM Template
- Navigate to [deploy an ARM template](https://portal.azure.com/#create/Microsoft.Template)
- Click on **Build your own Template in the Editor** ![editor](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-custom-deploy.PNG) </br>
- Copy and paste the [ARM Template](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/deploy/pipeline-with-mldotnet.json)
- Click "Save"

#### 2. Enter valid parameter values
- Select to create a new resource group and enter a name
- Enter a notification e-mail to be used (needs to be an Outlook or Office365 e-mail)
![final](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-custom-deploy-final.PNG) </br>

#### 3. Deploy
Select to agree with terms and conditions and click **Purchase** to trigger the deployment.

#### 4. Authenticate accounts
The ARM template will successfully set up the required infrastructure, but it will require you to authenticate your Outlook credentials manually.

**Authenticate Outlook notifier**
- Navigate to your Azure Logic App (fraudulent-notifier)
- Click on **Edit** ![logic app](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-edit-logic-app.png) </br>
- Click on the Outlook connection step and then the invalid connection symbol ![invalidconnection](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-invalid-outlook.png) </br>
- Log-in with your credentials
- Navigate back to the Logic App overview page
- Click **Enable** to enable your trigger
