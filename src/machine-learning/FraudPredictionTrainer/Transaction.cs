using Microsoft.ML.Data;

namespace FraudPredictionTrainer
{
    public sealed class Transaction
    {
        [ColumnName("Step"), LoadColumn(0)]
        public float Step { get; set; }

        [ColumnName("Type"), LoadColumn(1)]
        public string Type { get; set; }

        [ColumnName("Amount"), LoadColumn(2)]
        public float Amount { get; set; }

        [ColumnName("NameOrig"), LoadColumn(3)]
        public string NameOrig { get; set; }

        [ColumnName("OldbalanceOrg"), LoadColumn(4)]
        public float OldbalanceOrg { get; set; }

        [ColumnName("NewbalanceOrig"), LoadColumn(5)]
        public float NewbalanceOrig { get; set; }

        [ColumnName("NameDest"), LoadColumn(6)]
        public string NameDest { get; set; }

        [ColumnName("OldbalanceDest"), LoadColumn(7)]
        public float OldbalanceDest { get; set; }

        [ColumnName("NewbalanceDest"), LoadColumn(8)]
        public float NewbalanceDest { get; set; }

        [ColumnName("IsFraud"), LoadColumn(9)]
        public bool IsFraud { get; set; }

        [ColumnName("IsFlaggedFraud"), LoadColumn(10)]
        public float IsFlaggedFraud { get; set; }
    }
}
