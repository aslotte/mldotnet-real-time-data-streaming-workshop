## Introduction
Working with real-time data streams, and deriving real-time insights using custom machine learning models have become increasingly important for many organizations. There are numerous real-time data platforms currently available (e.g. Kafa, Hadoop Spark), but the one we will be focusing on in this workshop in particular is **Azure Stream Analytics**. In addition to diving in to Azure Stream Analytics, we will also explore the open-source cross-plattform library [ML.NET](https://github.com/dotnet/machinelearning), which we will use to build our custom machine learning models and look at an alternative solution using **Azure Machine Learning Service**.

## Setting up pre-requisites
<details>
  <summary>Instructions</summary>
  <p>
   1. Download the .NET Core SDK <br/>
   2. Install VS Code <br/>
   3. Install the C# Extension <br/>
   4. Install the Azure Function's Extension <br/>
   5. Install the ML.NET CLI
   6. Copy/Clone repo <br/>
   8. Download the data
   9. Create a free Azure subscription
   10. Download Azure Storage Explorer (optional)
   11. Create a Power BI account
   12. Create an Outlook e-mail  
  </p>
</details>

## Problem Outline
As a financial institution, detecting fraud is imperative to ensure safe and continuous operations for the bank and its customers.  

In this workshop we will be looking at detecting fradulent transactions in real-time. We will be training our model based on publicly available data from [Kaggle](https://www.kaggle.com/ntnu-testimon/paysim1) and integrating this custom machine learning model in a real-time data pipeline, supported by Azure Stream Analytics.

## Outline of Learning Objectives
- **Part 1**: [Machine Learning in .NET](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part1-ml.md)
  - Introduction to Machine Learning and ML.NET
  - Explore the data with Jupyter Notebooks and Pandas
  - Train a machine learning model using ML.NET
  - Train a machine learning model using AutoML CLI
- **Part 2**: [Setting up real-time data streaming pipeline](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-streaming.md)
  - Introduction to Stream Processing and Azure Stream Analytics
  - Introduction to Azure Resource Management (ARM) Templates
- **Part 3** [Machine Learning in Azure](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part1-azureml.md)
  - Introduction to Azure Machine Learning Service
  - Train a machine learning model using Azure ML Visual Interface
  - Train a machine learning using Azure AutoML
  - Train a machine learning using Jupyter Notebooks and  Scikit Learn
- **Part 4** [Consume ONNX Model from Jupyter Notebook in ML.NET](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part3-consume-onnx-model.md)
  - Consume an exported ONNX model in ML.NET, which was trained with Scikit Learn (Python)
  
**Reminder**: Remember to remove you resource group once finished with this workshop, not to incur additional costs.
  
## Solution Architecture 
#### A Real-Time Data Pipeline with ML.NET
![Real-Time Data Pipeline with ML.NET](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/Solution%20Architecture%20-%20ML.NET.png)


#### A Real-Time Data Pipeline with Azure Machine Learning Studio
![Real-Time Data Pipeline with Azure ML](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/Solution%20Architecture%20-%20Azure%20ML.png)

## Assumptions
This workshop is currently valid for ML.NET v1.3.1

## Additional Resources
- [ML.NET](https://github.com/dotnet/machinelearning)
- [ML.NET Samples](https://github.com/dotnet/machinelearning-samples)
- [Azure Stream Analytics](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-introduction)

