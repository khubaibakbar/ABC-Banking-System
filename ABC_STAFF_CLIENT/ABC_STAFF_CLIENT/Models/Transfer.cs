namespace ABC_STAFF_CLIENT.Models
{
    public class Transfer
    {
        public long Id { get; set; }
        public string SourceAccount { get; set; }
        public string TargetAccount { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
