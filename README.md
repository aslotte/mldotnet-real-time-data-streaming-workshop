## Introduction
Working with real-time data streams, and deriving real-time insights using custom machine learning models have become increasingly important for many organizations. There are numerous real-time data platforms currently available (e.g. Kafa, Hadoop Spark), but the one we will be focusing on in this workshop in particular is **Azure Stream Analytics**. In addition to diving in to Azure Stream Analytics, we will also explore the open-source cross-plattform library [ML.NET](https://github.com/dotnet/machinelearning), which we will use to build our custom machine learning models and look at an alternative solution using Azure Machine Learning Service.

## Pre-requisites
In order to complete the workshop, please ensure you have the following:
- [A free Azure subscription](https://azure.microsoft.com/en-us/free/)
- [A Kaggle account](https://www.kaggle.com/)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) or [VS Code](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)
- [ML.NET Model Builder (optional)](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet/model-builder)
- [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
- [A Power BI account](https://powerbi.microsoft.com/en-us/)
- [An Outlook e-mail](www.outlook.com)

## Assumptions
This workshop is currently valid for ML.NET v1.3.1.0

## Resources
- [ML.NET](https://github.com/dotnet/machinelearning)
- [ML.NET Samples](https://github.com/dotnet/machinelearning-samples)
- [Azure Stream Analytics](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-introduction)

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

