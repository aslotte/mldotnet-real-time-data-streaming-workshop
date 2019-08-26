### Kick-off the Event Producer
A streaming pipeline does not do much without events to process. 
In this workshop we will utilize an artifical event producer as a real-time event source for transaction data is difficult to find.

To start the event producer, please follow the steps below.

### Prerequisites
- Visual Studio 2017/2019 or VS Code

#### 1. Clone source code
Please clone this repository locally using for example a Git command prompt or Github Desktop.
Open the TransactionSimulator solution [here](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/tree/master/src/real-time-data-streaming/transaction-simulator/TransactionSimulator)

#### 2. Set configuration parameters
For the simulator to know where to send events, we need to update the event hub configuration parameters in appSettings.json

##### 2.1 Retrieve Event Hub Connection Settings
1. Navigate to your transaction-eh event hub namespace in Azure
2. In the menu to the left, click **Shared Access Policies**
3. Click on the **RootManagedShareAccessKey**
4. Copy the primary connection string to clipboard

![eh-keys](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/eh-access-keys.png)

#### 2.2 Alter appsettings.json
1. Back in the solution, open the appsettings.json file
2. Set the parameter **EventHubConnectionString** to the copied value

#### 3. Build and run solution
To start sending events to the event-hub, build and run the solution by pressing F5.
