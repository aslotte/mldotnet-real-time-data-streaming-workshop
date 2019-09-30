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