using Microsoft.ML.Data;

namespace FraudPredictionTrainer
{
    public sealed class Transaction
    {
        [ColumnName("step"), LoadColumn(0)]
        public float Step { get; set; }

        [ColumnName("type"), LoadColumn(1)]
        public string Type { get; set; }

        [ColumnName("amount"), LoadColumn(2)]
        public float Amount { get; set; }

        [ColumnName("nameOrig"), LoadColumn(3)]
        public string NameOrig { get; set; }

        [ColumnName("oldbalanceOrg"), LoadColumn(4)]
        public float OldbalanceOrg { get; set; }

        [ColumnName("newbalanceOrig"), LoadColumn(5)]
        public float NewbalanceOrig { get; set; }

        [ColumnName("nameDest"), LoadColumn(6)]
        public string NameDest { get; set; }

        [ColumnName("oldbalanceDest"), LoadColumn(7)]
        public float OldbalanceDest { get; set; }

        [ColumnName("newbalanceDest"), LoadColumn(8)]
        public float NewbalanceDest { get; set; }

        [ColumnName("isFraud"), LoadColumn(9)]
        public bool IsFraud { get; set; }

        [ColumnName("isFlaggedFraud"), LoadColumn(10)]
        public float IsFlaggedFraud { get; set; }
    }
}
