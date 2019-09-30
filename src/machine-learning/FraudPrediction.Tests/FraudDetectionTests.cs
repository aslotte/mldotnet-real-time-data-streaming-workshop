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
            var model = mlContext.Model.Load(@"X:\\MLModel.zip", out _);
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