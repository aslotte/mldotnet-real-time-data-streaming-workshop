### How to Kick-off the Event Producer
A streaming pipeline does not do much without events to process. 
In this workshop we will utilize an artifical event producer as a real-time event source for transaction data is difficult to find.

To start the event producer, please follow the steps below.

    - In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br> 
    - In the terminal window, execute the following command to navigate to the folder of the solution.</br>`cd C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\transaction-simulator\TransactionSimulator`
    - In the terminal window, execute the following command to open the folder in VS Code `code . -r`
    - Navigate to your transaction-eh event hub namespace in Azure
    - In the menu to the left, click **Shared Access Policies**
    - Click on the **RootManagedShareAccessKey**
    - Copy the primary connection string to clipboard
![eh-keys](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/eh-access-keys.png)
    - Navigate back to VS Code
    - Open the solutions `appsettings.json` file
    - Set the parameter `EventHubConnectionString` to the copied value
    - To start sending events to the event-hub, build and run the solution by pressing F5.