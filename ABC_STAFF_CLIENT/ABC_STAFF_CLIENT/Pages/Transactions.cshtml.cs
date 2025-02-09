using ABC_STAFF_CLIENT.API;
using ABC_STAFF_CLIENT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_STAFF_CLIENT.Pages
{
    public class TransactionsModel : PageModel
    {
        public string sessionToken { get; set; }

        public String accountNumber { get; set; }
        ApiService apiService=new ApiService();
        public IEnumerable<DWTransaction> transactions { get; set; }
        public IEnumerable<Transfer> transfers { get; set; }

        public async Task OnGet()
        {
            sessionToken = HttpContext.Session.GetString("token");
            accountNumber = Request.Query["accountNumber"];
            transactions = await apiService.GetDWTransactions();
            transfers=await apiService.GetTransfers();
        }
    }
}
