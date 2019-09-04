## Create a Streaming Power BI Dashboard
Please follow the steps below to get started with Power BI.</br></br>
**Note - this step is optional and only possible to complete if you possess a work or school account. It's not possible to create a Power BI account with a @gmail or @outlook address.**

### Create a Power BI Account
1. Navigate to https://powerbi.com 
2. Click on **Start Free**![start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-create.PNG)
3. Follow the provided instructions

### Create a Power BI Output
To output data from Azure Stream Analytics, we'll need to create an output.
1. Navigate to your Stream Analyics Job in Azure
2. Stop the job if it is running
3. Click on **Outputs** [streamAnalytics](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics.png)
4. Select to add an output and select Power BI in the list [output](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics-add-output.png)
5. Enter **powerbi** as output name
6. Enter **fraudulent** as dataset and table name [output1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-add-powerbi-output.PNG)
7. Click **Authorize**
8. Provide your Power BI credentials
9. Click **Save**
10. In the menu to the left, select **Query**
11. Uncomment the Power BI query [output1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-stream-analytics-query.PNG)
12. Save the changes
13. Go back to **Overview** and start the Stream Analytics Job

### Creating a dashboard
To create a dashboard, please follow the steps below:
1. Navigate to https://app.powerbi.com/ 
2. Sign-in to your account
3. Select to create a new dashboard [image here]
4. In the dashboard, select **Add tile**. 
5. For the tile type, select **Custom Streaming Data**
6. Select what kind of tile you would like to create
7. From the drop-down, select what value should be displayed

#### Example Dashboard
![Fraudulent](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/powerbi-example.PNG)
