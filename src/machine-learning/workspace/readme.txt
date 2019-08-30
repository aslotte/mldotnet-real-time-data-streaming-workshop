1. Open a Terminal by selecting View -> Terminal
2. In the Terminal window, paste the command
        dotnet new console -o FraudPredictionTrainer
3. Navigate to the newly created folder
        cd FraudPredictionTrainer
4. Install nuget packages for ML.NET by executing the following commands in the Terminal
        dotnet add package Microsoft.ML
        dotnet add package Microsoft.ML.FastTree
        dotnet add package Microsoft.ML.LightGbm