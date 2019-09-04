## Publish Azure Function to Predict Fraudulent Transactions
All incoming transactions get evaluated to determine if they are fraudulent or not based on our trained Machine Learning Model.
This prediction occurs in an Azure Function that needs to get deployed to Azure.

<br/>

To deploy the Azure Function from VS Code, please follow the steps listed below:

   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br> 
   - In the terminal window, execute the following command to navigate to the folder of the solution.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\fraud-prediction-function`
   - In the terminal window, execute the following command to open the folder in VS Code `code . -r`
   - In the menu to the left, select the Azure symbol (at the bottom-left of the menu)
   - Click **Sign-in to Azure** and sign in with your Azure credentials
    - In the top left, click on the up-arrow to **Deploy to Function App**
![deployToAzure](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/publish-function-vs-code-publish.png)
   - Select your Azure Subscription
   - Select your created Function App
   - If asked to update the Function apps run-time, select **Yes**
   - When asked if you're sure that you want to deploy the Function App, select **Yes**
   ![deploymentConfirm](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-deploy-function-confirm.PNG)