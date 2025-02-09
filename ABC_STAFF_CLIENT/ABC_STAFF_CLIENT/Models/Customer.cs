namespace ABC_STAFF_CLIENT.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string Branch { get; set; }

        public String password { get; set; }
    }
}
