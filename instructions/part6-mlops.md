### ML.NET + Azure DevOps = MLOps
How do you keep your model up to date, as your data and the code used during training changes?
What about automatic deployments to your Azure Function or ASP.NET Core Web API? 

Just as CI/CD and DevOps revolutionized development and infrastructure management, we can apply the same principles to the training and deployment of your machine learning model.
For demonstration purposes, we'll use Azure DevOps.

#### 1. Getting started
<details>
  <summary> Create an Azure DevOps account</summary>
  <p>
    
You can skip this section if you already have an account.    
1. Navigate to [Azure DevOps](https://dev.azure.com)
2. Click on **Start free** ![devops](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-1.PNG)
3. Follow the provided instructions to create a free account
  </p>
</details>

<details>
  <summary>Fork repository</summary>
  <p>
   
1. In the top right corner of this repo, click **Fork** </br>
2. Select to **Fork** this repository to your own Github account </br>
  </p>
</details>

#### 2. Set up a CI pipeline
<details>
  <summary> Setting up a CI pipeline</summary>
  <p>
    
1. Navigate to [Azure DevOps](https://dev.azure.com)
2. Click on **New Project** in the top-right corner ![newproject](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-new-project.PNG)
3. Give the new project a name, e.g. `fraud-detection`
4. In the menu to the left, click on **Builds** and then **New pipeline** ![newproject](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-new-pipeline.PNG)
5. In the list, select **GitHub**
6. In the list of repositories, select the new repository you just forked
7. You may be asked to enter your Github account for authentication
8. Click on **Approve and Install** to install Azure Pipelines in the forked repository ![approve](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-approve-and-install.PNG)
9. Select **Starter pipeline** ![starter](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-configure.PNG)
10. Let's make some changes to the default YAML file. </br>

10.1. Change the VM image to
```
pool:
  vmImage: 'windows-latest'
```
10.2. Add a variables section </br>
```
variables:
  buildConfiguration: 'Release'
```
10.3. Replace the current steps with </br>
```
- script: dotnet build src/machine-learning/FraudPredictionTrainer/FraudPredictionTrainer.csproj --configuration $(buildConfiguration)
  displayName: 'Build Trainer Console App (dotnet build) $(buildConfiguration)'

- script: dotnet run --project src/machine-learning/FraudPredictionTrainer/FraudPredictionTrainer.csproj --configuration $(buildConfiguration)
  displayName: 'Train ML model (dotnet run)'
```
The steps above builds and runs the console application used to train our model in a windows image.

Your YAML file should now look like ![pipeline](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-default-pipeline.PNG)

11. In the top-right corner, click **Save and Run** </br>

If you have a look at the completed build, you'll see that it failed. This is because the console application cannot find the `data.csv` file used for training, as it is not a part of the repository. For smaller data sources, it may make sense to include them in the repository. For any file larger than 100 Mb, we can instead store it in an Azure fileshare, and mount the share as a separate step in the build. Let's have a look at how this can be done.



##### 2.1. Create and mount an Azure Fileshare to the build pipeline
1. Navigate to the [Azure portal](https://portal.azure.com)
2. Navigate to a previously created storage account ([part 2](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-streaming.md)
3. In the storage account, select **File shares** ![files](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-fileshare.png)
4. In the top-middle, click on **+ File share**
5. Give the file share a name, e.g. `data`
6. Click **Create**

_As the current data source is 500+ Mb large, we'll only use a small portion of the total amount of data for demonstrational purposes. This will speed up the build process._

7. Upload the following [file](https://aslottepublic.blob.core.windows.net/small/data.csv) to your newly created file share 


- Attaching it during the pipeline
- Modifying the code to point to new location

</p>
</details>

#### 3. Adding unit tests

#### 4. Set up a CD pipeline
