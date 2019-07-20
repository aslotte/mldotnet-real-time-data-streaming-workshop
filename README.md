## Introduction
Working with real-time data streams, and deriving real-time insights have become increasingly important for many organizations. There are numerous real-time data platforms currently available (e.g. Kafa, Hadoop Spark), but the one we will be focusing on in this workshop in particular is **Azure Stream Analytics**. In addition to diving in to Azure Stream Analytics, we will also explore the open-source cross-plattform library ML.NET.

## Preparations
The following is required to complete the below outlined workshop:
- An Azure subscription
- A Kaggle account
- Visual Studio 2017/2019

## Todo
- [X] Define problem to solve
- [ ] Write ARM templates to setup the streaming pipeline
- [ ] Write simulator for potential data source
- [ ] Aquire data to train model on
- [ ] Train the model 

## Problem to solve
- Financial Analysis to detect fradulent transactions in real-time
- Datasource: https://www.kaggle.com/ntnu-testimon/paysim1/version/2

## Outline of Learning and Objectives
- **Part 1**: Train a Machine Learning Model using ML.NET
  - Setup your own training pipeline
  - Utilize AutoML CLI to train your model
  - Deploy prediction engine
- **Part 2**: Setup real-time data streaming pipeline

## Separate parts
- **Part 0**- An introduction to Azure Stream Analytics
- **Part 1**- Working with event producers and data ingress
- **Part 2**- Azure Stream Analytics SQL - Querying a real-time data stream 
- **Part 3**- Setting up and managing an Azure Stream Analytics job
- **Part 4**- Working with data egress
- **Part 5**- An introduction to machine learning and ML.NET
- **Part 6**- Training our machine learning model
- **Part 7** - Deploying a serverless prediction engine
- **Part 8** - Integrating real-time data streaming with machine learning

## Part 1 - Streaming data sources
1. Create an Event Hub namespace
2. Create an Event Hub
3. Create a Logic App
4. Open the Logic app designer and select to listen to a Twitter feed
5. Authenticate yourself towards Twitter
6. Add a new step, with sending the events to our Event Hub
7. Add a ContentParameter with value triggerBody()
8. Open VS - create a Azure Stream Analytics job, add input, add SQL, remember output time

## Ideas
- Fraud Analytics
- Spam filter
- Click-stream analytics
- Anomaly detection


