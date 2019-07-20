## Introduction
Working with real-time data streams, and deriving real-time insights using custom machine learning models have become increasingly important for many organizations. There are numerous real-time data platforms currently available (e.g. Kafa, Hadoop Spark), but the one we will be focusing on in this workshop in particular is **Azure Stream Analytics**. In addition to diving in to Azure Stream Analytics, we will also explore the open-source cross-plattform library ML.NET, which we will use to build our custom machine learning models.

## Prerequisites
In order to complete the workshop, please ensure you have the following:
- An Azure subscription
- [A Kaggle account](https://www.kaggle.com/)
- Visual Studio 2017/2019

## Problem outline
- Financial Analysis to detect fradulent transactions in real-time
- Datasource: https://www.kaggle.com/ntnu-testimon/paysim1/version/2

## Outline of Learning and Objectives
- **Part 1**: Machine Learning in .NET
  - An introduction to Machine Learning and ML.NET
  - Explore the data
  - Train a machine learning model using ML.NET
  - Train a machine learning model using AutoML CLI
  - Train a machine learning model using Azure Machine Learning Studio
- **Part 2**: Setting up real-time data streaming pipeline
  - An introduction to Azure Stream Analytics
  - Setting up a real-time data pipeline
 - **Part 3**: Integrate our real-time data pipeline with our model
  - Deploy our ML.NET model as an Azure Function
  - Deploy integrate Azure ML through Azure Stream Analytics

## Todo
- [X] Define problem to solve
- [ ] Write ARM templates to setup the streaming pipeline
- [ ] Write simulator for potential data source
- [ ] Aquire data to train model on
- [ ] Train the model 
