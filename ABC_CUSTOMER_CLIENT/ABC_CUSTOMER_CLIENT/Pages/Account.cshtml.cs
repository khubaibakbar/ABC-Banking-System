using ABC_CUSTOMER_CLIENT.Models;
using ABC_CUSTOMER_CLIENT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_CUSTOMER_CLIENT.Pages
{

    
    public class AccountModel : PageModel
    {
        public Account? account { get; set; }

        public IEnumerable<DWTransaction> transactions { get; set; }    
        public IEnumerable<Transfer> transfers { get; set; }

        public String sessionToken { get; set; }

        private ApiService apiService =new ApiService();
        public async Task OnGet()
        {
            sessionToken = HttpContext.Session.GetString("token");
            IEnumerable<Account> accounts=await apiService.GetAllAccounts();
            foreach(Account acc in accounts)
            {
                if (acc.AccountNumber == sessionToken)
                {
                    account = acc;
                }
            }

            //retrieve the transactions and accounts
            transactions = await apiService.GetDWTransactions();
            transfers=await apiService.GetTransfers();
        }
    }
}
