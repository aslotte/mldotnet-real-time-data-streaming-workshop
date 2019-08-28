## Training your Machine Learning Model using Azure Machine Learning Service
ML.NET offers fantastic support to train your model offline using C#. Training your model using ML.NET however requires you to manually set up your compute environment for larger machine learning models, and currently limits you from the possibility of training more complex neural networks. An alternative to ML.NET is to use Azure Machine Learning Service, which is Azure's managed machine learning environment. There are three ways to train your custom machine learning model in the service, using Azure's AutoML functionality, a visual interface or using Jupyter Notebooks with full support for custom models in Python or R. 

**Please note:** At time of writing, integrating ML models trained in Azure Machine Learning Service with Azure Stream Analytics is currently not supported. Stream Analytics currently only support models trained in Azure Machine Learning **Studio**. There will however be a release in the near future changing this. This workshop will regardless focus on Azure Machine Learning Service as this is what will be supported going forward.

### Prerequisites
- [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

### 1. Provision resources 
<details>
  <summary> Provision resources </summary>
  <p>
    
Before we can start to train our models, we need to provision our resources. Please follow the following [guide](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-stream-azureml.md) which will provision both an Azure Machine Learning Service instance as well as streaming pipeline to integrate our models with.

</p>
</details>

### 2. Create compute targets
<details>
  <summary> Create compute targets </summary>
  <p>
    
Our machine learning models will be trained and deployed using various compute targets. Please follow the instructions below to create the compute targets needed throughout this section:

1. Navigate to the Azure Machine Learning Service in Azure.
2. In the left menu, select **Compute**

![compute](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-compute-1.PNG)
3. Create a **Machine Learning Compute** according to the image below

![compute](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-compute-ml-1.PNG)
4. Create a **Kubernetes compute** according to the image below

![compute](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-compute-kubernetes-1.PNG)

</p>
</details>

### 3. Visual Interface

<details>
  <summary> Steps to train your model using the Visual Interface </summary>
  <p>

- Navigate to the Azure Machine Learning Service in Azure.
- In the left menu, select **Visual Interface**
- Select **Launch visual interface**

This will open the Machine Learning workspace in which we can create experiments using a visual interface.
Feel free to navigate around to make yourself familiar with the surroundings. 

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-1.PNG)

#### Upload our data
The first thing we would like to do is to upload our data set. To this, click on the **New** button in the bottom-left corner. Select to **Upload from Local File**

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-2.PNG)

#### Create a new experiment
Once the dataset has been uploaded, click the **New** button once again and select to create a new **Blank Experiment**

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-3.PNG)

That should present you with the view below:
![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-4.PNG)


### Setting up our experiment 
Use the left-most menu to set up our experiment. The visual interface functions such that you can drag and drop operations and connect them together in a training pipeline. 

The following operations are required
- The data source
- Select columns in data set (column indices 1-10)
- Split Data (0.7 split)
- Two-Class Boosted Decision Tree (set the maximum number of leaves to 10 and the learning rate to 0.1)
- Train Model (set the label-column to isFraud)
- Score Model
- Evaluate Model

The experiment should eventually look like:
![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-5.PNG)

### Running your experiment
To run your experiment, simply click **Run** in the bottom task bar and select our previously created compute target called **experiment**
Training the model will take about 15 min.

### Evaluate your model
Once training has completed, right click on the **Evaluate Model** step and click to Visualize the Evaluation results
![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-6.PNG)

We can see that our model generated by the Visual Interface have similar accuracy as the one generated by ML.NET, but not the same quality in terms of precision and recall. 

### Deploy model for consumption
To be able to integrate our ML model in to our data streaming pipeline, we would need to deploy it as a web service. 
To do so, please click the button **Create New Predictive Experiment** in the bottom right corner.

This will create a predictive experiment tab, with web inputs and outputs. To prepare the service for deployment, please click **Run**
This step will take about the same time to complete as the training step did.

![predictive](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/predictive-experiement-1.PNG)

Once building your web-service has completed, click **Deploy Web Service**

![predictive](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/predictive-experiement-2.PNG)

In the modal that appears, select the previously created compute **web-service** and click **Deploy**
![predictive](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/predictive-experiement-3.PNG)

</p>
</details>

### 4. AutoML
<details>
  <summary> Steps to train your model using Azure AutoML </summary>
  <p>
    
Similarly to ML.NET's AutoML functionality, Azure provides its own. This is a very neat functionality, as it allows you to get a jump start on training advanced model with little to no previous Machine Learning experience. 

### Upload our data
First thing we need to do before diving in to Azure AutoML is to upload our dataset to our storage account using the [Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/). There is a size limit uploading large files through the web interface, thus we have to reside to the storage explorer for our 450+ Mb file.  To do this, download and open the Azure Storage Explorer, navigate to your mlmodel storage account and upload the file to the container called model.

### Create a new experiment 

1. To create our first AutoML experiment, open the Azure Machine Learning Service in Azure and click on **Automated Machine Learning** to the left.

![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-1.png)
    
2. Click **Create Experiment**
3. Enter an experiment name 
![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-2.PNG)
4. Select the compute target named **experiment** previously created
5. Click **Next**
6. Select the storage account named **mlmodel**
7. Select the container named **model**
![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-4.PNG)
8. Select the file data.csv which was uploaded in the previous step
9. Scroll down and select **isFraud** as the target column and classification as prediction task
![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-5.PNG)
10. Expand the **Advanced Settings**
11. Set the training job time to 20 min and change the primary metric to norm_macro_recall
![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-6.PNG)
12. Click **Start**

While this experiment is running, lets take a moment to reflect on why we changed primary metric from accuracy to recall. If you remember earlier in this workshop, we discussed the fact that the data is highly unbalanced, meaning that if the algorithm just guesses non-fraudulent on everything it will achieve a 99.8% accuracy. Although accuracy is important for us, achieving a higher recall (minimum number of false negatives) is crucial.

Once the run has completed, you can navigate to the result by
1. Selecting **Automated Machine Learning** in the left menu
2. Clicking on the run id for your run

If you scroll down, you'll both see a chart presenting the training metrics vs iterations as well as which models the AutoML algorithm has tried.

### Deploy model for consumption
Once we are happy with our model, we can deploy it to be consumed by an external service.

1. Click the button **Deploy Best Mode** in the top right corner

![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-8.PNG)
2. In the pane that appears, enter a name for your deployment

![automl1](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-auto-ml-9.PNG)
3. Click **Deploy**

  </p>
</details>  

### 5. Jupyter Notebooks
<details>
  <summary> Steps to train your model using Jupyter Notebooks </summary>
  <p>
    
The Visual interface and Azure AutoML offers options to train your custom ML model without too much previous knowledge in machine learning. If you would like complete control over the training process, as well as wanting to use Python based open-source libraries such as ScikitLearn, Pandas and Numpy, Azure offers the option to provision Jupyter Notebook VMs. This allows you to create your own notebook and attach and run operations in Kubernetes clusters. 
    
To start training your model, please do the following:
1. Navigate to your Azure Machine Learning Service in Azure
2. In the menu to the left, click Notebooks VMs
3. Click **New** to create a new Jupyter VM
4. Provide the machine with a new name and click create
5. Once created, start the VM
6. Once started, click **JupyterLab**

This will take you to the Jupyter environment hosted on your VM.

In the notebook we will learn how to train a simple classifier using Sklearn.
We will deploy our model to a Docker image in an Azure Container Instance as well as output the model as .pkl file and in the ONNX open standard for use in e.g. ML.NET

In Jupyter lab:
1. Upload our data file
2. Upload the following [Jupyter Notebook](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/src/machine-learning/jupyter/jupytervm/fraudulent-transactions.ipynb)
  
Run and explore the Notebook.

  </p>
</details>  

### 6. Integrating our model with Azure Stream Analytics
<details>
  <summary> Integrating our model with Azure Stream Analytics </summary>
  <p>
    As stated earlier, Azure Stream Analytics currently do not support the new Azure Machine Learning Service. However, this is on the roadmap and will be supported in the near future. As such, we will be describing the generic steps to perform the integration when available
    
   #### Add an ML function Azure Stream Analytics
   1. Navigate to your Stream Analytics Job
   2. In the menu to the left, click **Functions**
   3. In the top left corner, click Add => Azure ML
   
   ![addfunction](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/add-ml-function.png) 
   4. In the pane that appears, select the deployed ML model/service and enter a name (this name will be used in your query)
   5. Once the function has been added, you can call the function from you query, e.g. isFraudulant(input.text)
  </p>
</details> 

