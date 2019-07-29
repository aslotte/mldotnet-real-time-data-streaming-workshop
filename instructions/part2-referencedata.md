### Upload reference data
The real-time pipeline utilizes reference data to enrich the stream. 
In this particular case we will be enriching the stream with information about where to send an notification e-mail in case the model detects a fraudulant transaction. Please navigate to your storage account and upload the [reference-data.json](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/real-time-data-streaming/stream-analytics/reference-data.json) file in to the container named "reference"

Extract of file:

```  
[
    {
        "customerid": "C1305486145",
        "email": "alexander.slotte.demo@outlook.com"
    },
    ....
```
