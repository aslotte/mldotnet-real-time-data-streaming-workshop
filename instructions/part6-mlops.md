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
  <summary>Create a new Github</summary>
  <p>
   
1. Create a new private Github repository (either using the cmd tool or via github.com) </br>
2. Copy/paste the `FraudPredictionTrainer` folder from `\src\machine-learning\` to your new repository </br>
3. Remove the data.csv file if it exist
4. Commit and push to your new repository </br>
  </p>
</details>

#### 2. Setting up a CI pipeline
<details>
  <summary> Setting up a CI pipelinet</summary>
  <p>
    
1. Navigate to [Azure DevOps](https://dev.azure.com)
2. Click on **New Project** in the top-right corner ![newproject](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-new-project.PNG)
3. Give the new project a name, e.g. `fraud-detection`
4. In the menu to the left, click on **Builds** and then **New pipeline** ![newproject](https://github.com/aslotte/mldotnet-real-time-data-streaming-workshop/blob/master/instructions/images/azure-devops-new-pipeline.PNG)
5. In the list, select **GitHub**
6. In the list of repositories, select the new repository you've just created
7. 

- Creating a build pipeline
- YAML
- Creating an Azure File share
- Uploading a small file
- Attaching it during the pipeline
- Modifying the code to point to new location

</p>
</details>

#### 3. Adding unit tests

#### 4. Setting up a CD pipeline
