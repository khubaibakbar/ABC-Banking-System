namespace ABC_CUSTOMER_CLIENT.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public double Overdraft { get; set; }

        public string Branch { get; set; }

        public Customer Customer { get; set; }

    }
}
