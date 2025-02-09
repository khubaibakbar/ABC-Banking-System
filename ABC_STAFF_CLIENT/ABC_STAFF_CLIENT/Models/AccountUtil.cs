namespace ABC_STAFF_CLIENT.Models
{
    public class AccountUtil
    {
        public String branch { get; set; }
        public String names { get; set; }

        public String email { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String password { get; set; }

        public AccountUtil(Account acc) {
            this.branch = acc.Branch;
            this.names = acc.Customer.Names;
            this.phone = acc.Customer.Phone;
            this.address = acc.Customer.Address;
            this.password = acc.Customer.password;
            this.email = acc.Customer.Email;
        }

        public String ToString()
        {
            return "{" +
                "\"branch\":" + branch + "," +
                "\"names\":" + names + "," +
                "\"email\":" + email + "," +
                "\"phone\":" + phone + "," +
                "\"address\":" + address + "," +
                "\"password\":" + password + "}";
        }
    }
}
