namespace FraudPredictionFunction
{
    public class Transaction
    {
        public int Step { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string NameOrig { get; set; }
        public decimal OldBalanceOrg { get; set; }
        public decimal NewBalanceOrig { get; set; }
        public string NameDest { get; set; }
        public decimal OldBalanceDest { get; set; }
        public decimal NewBalanceDest { get; set; }
        public bool IsFraud { get; set; }
    }
}
