using Microsoft.ML.Data;

namespace FraudPredictionFunction
{
    class FraudPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsFraud { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
