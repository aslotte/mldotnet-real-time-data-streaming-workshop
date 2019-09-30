### ML.NET + Azure DevOps = MLOps
How do you keep your model up to date, as your data, and code used during training changes?
What about automatic buil and deployments to production environments?

Just as CI/CD and DevOps revolutionized development and infrastructure management, we can apply the same principles to the training and deployment of our machine learning model.

For demonstration purposes we'll be using Azure DevOps.

![mlops](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/mlops.png)

#### 1. Getting started
<details>
  <summary> Getting started</summary>
  <p>
    
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

</p>
</details>

#### 2. Set up Continuous Integration
<details>
  <summary>Set up Continuous Integration</summary>
  <p>
    
1. Navigate to [Azure DevOps](https://dev.azure.com)
2. Click on **New Project** in the top-right corner
3. Give the new project a name, e.g. `fraud-detection`
4. In the menu to the left, click on **Builds** and then **New pipeline** ![newproject](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-new-pipeline.PNG)
5. In the list, select **GitHub** ![starter](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-select-git.PNG)
6. In the list of repositories, select the new repository you just forked
7. You may be asked to enter your Github account for authentication
8. Click on **Approve and Install** to install Azure Pipelines in the forked repository
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

##### 2.1. Create an Azure Fileshare 
1. Navigate to the [Azure portal](https://portal.azure.com)
2. Navigate to a previously created storage account ([in part 2](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/part2-streaming.md))
3. In the storage account, select **File shares** ![files](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-storage-fileshare.png)
4. In the top-middle, click on **+ File share**
5. Give the file share a name, e.g. `data`
6. Click **Create**

_As the current data source is 500+ Mb large, we'll only use a small portion of the total amount of data for demonstrational purposes. This will speed up the build process._

7. Upload the following [file](https://aslottepublic.blob.core.windows.net/small/data.csv) to your newly created file share 

##### 2.2. Mount the Azure Fileshare as part of a build step
1. Navigate back to [Azure DevOps](https://dev.azure.com)
2. If you're not already in your YAML file, click the **Edit** button in the top-right corner to edit your build pipeline

In your YAML file, add the snippet below as a first step (**replace the placeholder with the name of your storage account**)
```
- script: 'net use X: \\nameofyourstorageaccount.file.core.windows.net\data /u:nameofyourstorageaccount $(filestorage.key)'
  displayName: 'Map disk drive to Azure Files share folder'
```
3. Replace the variables section with:
```
variables:
- group: fraud-detection
- name: buildConfiguration
  value: 'Release'
```
4. Click **Save**

Your YAML file should now like like:
![pipeline](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-pipeline-with-mount.PNG)

The final piece that is missing, is a variable holding the access key to your fileshare. 

5. In Azure DevOps, navigate to variable groups, by clicking on the **Library** menu item to the left
6. Click on **+ Variable group** ![variablegroup](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-variable-group.PNG)
7. Name the variable group **fraud-detection**
8. Add a new variable called **filestorage.key**
9. Set the value of the variable to the access key of your storage account ![variablegroup](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-finished-variable-group.PNG)
10. Make sure to check the lock symbol to the right, so that the variable becomes a secret variable
11. Click **Save**

To queue a new build, click on the **Queue** button in the top-right corner. The build should now complete succesfully in about 2 min.

</p>
</details>

#### 3. Set up Continuous Delivery
<details>
  <summary>Set up Continuous Delivery</summary>
  <p>
    We now have a continuous integration pipeline set up, in which a new model is trained each time any check-in to the repository is made. We can take this one step further and deploy the MLModel.zip to our Azure storage account on completion of the build.
    
   1. In Azure DevOps, click on **Project Settings** in the bottom-left corner
   2. In the menu that appears, click on **Service Connections** (under pipelines) ![service](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-service-connection.PNG)
   3. Click on **+ New Service Connection** and select **Azure Resource Manager** in the list
   4. In the modal that appears, give the connection the name of **Azure** and select your subscription
   5. Click **OK** to close the modal
   6. In Azure DevOps, navigate back to your build's YAML file
   7. Copy/paste the following as the last step. Replace the placeholder with the name of your storage account
   
   ```
   - task: AzureFileCopy@3
  inputs:
    SourcePath: 'MLModel.zip'
    azureSubscription: 'Azure'
    Destination: 'AzureBlob'
    storage: '{name-of-your-storage-account}'
    ContainerName: 'model'
   ```
   
   8. Click **Save**
   
   Your YAML file should now look like: ![service](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-after-deploy.PNG)
   
Great job! You've now successfully set up a CI/CD pipeline for your model. This pipeline can be further extended with triggers for changes in data, or additional unit and integration tests to ensure the model performance as expected.
  </p>
</details>

#### 4. Add Automated Testing
<details>
  <summary>Add Automated Testing</summary>
  <p>
   
  In the same way as we can add unit tests to test our regular code base, we can add unit tests to test the performance of our model.
  Let's have a look at how we can do just that.
  
  1. Open VS Code
  2. In VS Code, select Terminal -> New Terminal to open a new terminal window<img src="https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/vscode-open-terminal.png"></li>
  3. Navigate to `{location of forked repo}\mldotnet-real-time-data-streaming-workshop\src\machine-learning`
  4. In the terminal, execute the following command to create a new test project `dotnet new nunit -o FraudPrediction.Tests`
  5. In the terminal, execute the following command to navigate to the location of the new test project `cd FraudPrediction.Tests`
  6. In the terminal, execute the following command to open the folder in VS Code `code . -r`
  7. Open a new terminal and execute the following command to add the required NuGet packages 
  ```
  dotnet add package Microsoft.ML
  ```
  8. Open the project file called `FraudPrediction.Tests.csproj`
  9. Within `ItemGroup` add a project reference to `FraudPredictionTrainer.csproj`
  ```
      <ProjectReference Include="..\FraudPredictionTrainer\FraudPredictionTrainer.csproj" />
  ```
  10. Delete the default `UnitTest1.cs` class
  11. Add a new class called `FraudPredictionTests.cs`
  12. Copy the following to the new class
  ```
using NUnit.Framework;
using FraudPredictionTrainer;
using Microsoft.ML;

namespace FraudPrediction.Tests
{
    [TestFixture]
    public class FraudDetectionTests 
    {
        private PredictionEngine<Transaction, FraudPrediction> predictionEngine;

        [SetUp]
        public void SetUp()
        {
            var mlContext = new MLContext();
            var model = mlContext.Model.Load("..\\..\\..\\..\\FraudPredictionTrainer\\MLModel.zip", out _);
            predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, FraudPrediction>(model);
        }

        [Test]
        public void Predict_GivenNonFraudulentTransaction_ShouldReturnFalse()
        {
            //Arrange
            var transaction = new Transaction 
            {
                    Amount = 1500f,
                    OldbalanceDest = 100,
                    NewbalanceDest = 300,
                    NameDest = "C123",
                    NameOrig = "B123"
            };

            //Act
            var result = this.predictionEngine.Predict(transaction);

            //Assert
            Assert.IsFalse(result.IsFraud);
        }

    }
}
  ```
13. Add a new class called `FraudPrediction.cs`
14. Copy the following to the new class
```
using Microsoft.ML.Data;

namespace FraudPrediction.Tests 
{
    public class FraudPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsFraud { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
```
15. In the terminal, execute the following command to build the solution `dotnet build`
16. To run the test, execute the following command in the terminal window `dotnet test`
17. Commit and push the changes to your repository

Congratulations! You've just created your first unit test to test your machine learning model.
Let's see if we can integrate this test in our CI/CD pipeline.

1. Navigate to [Azure DevOps](https://dev.azure.com)
2. Open the build's YAML file
3. Copy/paste the following as the second-to-last step (before the copy to blob storage step)
```
- task: DotNetCoreCLI@2
  displayName: 'Run Unit Tests using trained ML model'
  inputs:
    command: test
    projects: 'src/machine-learning/FraudPrediction.Tests/FraudPrediction.Tests.csproj'
    arguments: '--configuration $(buildConfiguration)'
```
4. Click **Save** and queue up a new build to see test run as part of the build

Your YAML file should now look like:
![finalyaml](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-final-yaml.PNG)
  </p>
</detail>
