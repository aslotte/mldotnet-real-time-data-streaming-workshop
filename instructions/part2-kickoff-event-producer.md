### How to Kick-off the Event Producer
A streaming pipeline does not do much without events to process. 
In this workshop we will utilize an artifical event producer as a real-time event source for transaction data is difficult to find.

To start the event producer, please follow the steps below.

   - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br> 
   - In the terminal window, execute the following command to navigate to the folder of the solution.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\transaction-simulator\TransactionSimulator`</br> 
   - In the terminal window, execute the following command to open the folder in VS Code `code . -r`</br> 
   - Navigate to your transaction-eh event hub namespace in Azure</br> 
   - In the menu to the left, click **Shared Access Policies**</br> 
   - Click on the **RootManagedShareAccessKey**</br> 
   - Copy the primary connection string to clipboard</br> 
![eh-keys](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/eh-access-keys.png)
   - Navigate back to VS Code</br> 
   - Open the solutions `appsettings.json` file</br> 
   - Set the parameter `EventHubConnectionString` to the copied value</br> 
   - To start sending events to the event-hub, build and run the solution by pressing F5.</br> 
