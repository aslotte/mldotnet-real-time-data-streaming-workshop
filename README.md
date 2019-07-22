## Introduction
Working with real-time data streams, and deriving real-time insights using custom machine learning models have become increasingly important for many organizations. There are numerous real-time data platforms currently available (e.g. Kafa, Hadoop Spark), but the one we will be focusing on in this workshop in particular is **Azure Stream Analytics**. In addition to diving in to Azure Stream Analytics, we will also explore the open-source cross-plattform library ML.NET, which we will use to build our custom machine learning models.

## Pre-requisites
In order to complete the workshop, please ensure you have the following:
- [A free Azure subscription](https://azure.microsoft.com/en-us/free/)
- [A Kaggle account](https://www.kaggle.com/)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
- [ML.NET Model Builder (optional)](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet/model-builder)
- [PowerBI](https://powerbi.microsoft.com/en-us/)

## Assumptions
This workshop is currently valid for ML.NET v1.2.0.0

## Problem outline
As a financial institution, detecting fraud is imperative to ensure safe and continuous operations for the bank and its customers.  

In this workshop we will be looking at detecting fradulent transactions in real-time. We will be training our model based on publicly available data from [Kaggle](https://www.kaggle.com/ntnu-testimon/paysim1) and integrating this custom machine learning model in a real-time data pipeline, supported by Azure Stream Analytics.

## Solution Architecture 
#### A Real-Time Data Pipeline with ML.NET
![Real-Time Data Pipeline with ML.NET](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/Solution%20Architecture%20-%20ML.NET.png)


#### A Real-Time Data Pipeline with Azure Machine Learning Studio
![Real-Time Data Pipeline with Azure ML](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/Solution%20Architecture%20-%20Azure%20ML.png)

## Outline of Learning and Objectives
- **Part 1**: [Machine Learning in .NET](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part1-ml.md)
  - Introducing Machine Learning and ML.NET
  - Explore the data
  - Train a machine learning model using ML.NET
  - Train a machine learning model using AutoML CLI
  - Train a machine learning model using Azure Machine Learning Studio
- **Part 2**: [Setting up real-time data streaming pipeline](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-streaming.md)
  - Introducing Azure Stream Analytics
  - Setting up a real-time data pipeline

## Todo
- [X] Define problem to solve
- [ ] Write ARM templates to setup the streaming pipeline
- [X] Write simulator for potential data source
- [X] Aquire data to train model on
- [ ] Train the model in ML.NET
- [ ] Setup workshop solution for ML.NET (partially filled in)
- [ ] Describe steps to train model using AutoML CLI
- [ ] Train model using Azure Machine Learning
- [ ] Describe steps to train model using Azure Machine Learning
- [X] Create Azure Function for ML.NET model
- [X] Understand why AutoML is training a model using ML.NET v1.0.0.0 not v1.2.0.0
- [ ] Add more fraudelent data in the simulator data file
- [ ] Will it be expensive to use the storage account for ML.NET model?
