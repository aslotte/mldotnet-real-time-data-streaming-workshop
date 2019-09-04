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
2. Click on **Outputs** [image here]
3. Select to add an output [image here]
4. Select Power BI in the list
5. Select to **Authorize Power BI** [image here]
6. Provide your Power BI credentials
7. Provide a name for your dataset 
8. Give your output a name of **powerbi** [image here]
9. In the menu to the left, select query
10. Select to edit the query
11. Uncomment the Power BI query
12. Save the query
13. Start the Stream Analytics Job

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
