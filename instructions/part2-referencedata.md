### Upload reference data
The real-time pipeline utilizes reference data to enrich the stream. 
In this particular case we will be enriching the stream with information about where to send an notification e-mail in case the model detects a fraudulant transaction.

To upload the reference data, please do the following:
- In VS Code, open a new terminal window ![terminal](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png) </br>
- In the terminal window, execute the following command to open the `reference-data.json` file </br> 
`code C:\mldotnet-real-time-data-streaming-workshop\src\real-time-data-streaming\stream-analytics\reference-data.json`![refData](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-reference-data.PNG)
- In Azure, navigate to your storage account starting with mlmodel and select **Blob** ![storageAccount](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-blob.png)
- Select the container named **reference**
- Click on **Upload** and browse to and upload the reference-data.json file. ![upload](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-upload.png)
