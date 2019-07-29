## Training your Machine Learning Model using Azure Machine Learning Service
ML.NET offers fantastic support to train your model using C# and offline. Another way to train your model is by utilizing Azure, and in particular Azure Machine Learning Service. Azure Machine Learning Service currently do not offer support for training your models using C#, but rather relies on Jupyter Notebooks and Python. There is however an similar AutoML interface that can be used, as well as visual designer that's neat to setup your training pipeline

### Prerequisites
- Azure Machine Learning Service (please set up a data pipeline using the [following instructions](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-streaming.md) first 

### Visual Interface
- Navigate to your Azure Machine Learning Service, previously created
- Select "Visual Interface" in the menu to the left
- Select "Launch visual interface"

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-1.PNG)

#### Upload Dataset
This will open the Machine Learning Workspace. Feel free to navigate around to make yourself familiar with the surroundings. 
The first thing we would like to do is to upload our data set. To this, click on the "New" button in the bottom-left corner. Select to "Upload from Local File"

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-2.PNG)

#### Create a new experiment
Once the dataset has been uploaded, click the "New" button once again and select to create a new "Blank Experiment"

![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-3.PNG)

That should present you with the view below:
![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-4.PNG)


### Setting up our experiment 
Use the left-most menu to set up our experiment. The visual interface functions such that you can drag and drop operations and connect them together in a training pipeline. 

The following operations are required
- The data source
- Select columns in data set (column indicies 1-10)
- Split Data (0.7 split)
- Two-Class Boosted Decision Tree (set the maximum number of leaves to 10 and the learning rate to 0.1)
- Train Model (set the label-column to isFraud)
- Score Model
- Evaluate Model

The experiment should eventually look like:
![Start](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-ml-5.PNG)

### Running your experiment
To run your experiment, simply click Run in the bottom task bar.
Training the model will take about 15 min.

### Evaluate your model
Once training has completed, right click on the "Evaluate Model" step and click to Vizualize the Evaluation results 

### AutoML

### Jupyter Notebooks
