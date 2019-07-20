# Real-Time Data Streaming Pipeline

1. Create an Event Hub namespace
2. Create an Event Hub
3. Create a Logic App
4. Open the Logic app designer and select to listen to a Twitter feed
5. Authenticate yourself towards Twitter
6. Add a new step, with sending the events to our Event Hub
7. Add a ContentParameter with value triggerBody()
8. Open VS - create a Azure Stream Analytics job, add input, add SQL, remember output time
