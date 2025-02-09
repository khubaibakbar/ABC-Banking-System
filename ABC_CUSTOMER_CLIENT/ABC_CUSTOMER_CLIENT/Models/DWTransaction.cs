namespace ABC_CUSTOMER_CLIENT.Models
{
    public class DWTransaction
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
