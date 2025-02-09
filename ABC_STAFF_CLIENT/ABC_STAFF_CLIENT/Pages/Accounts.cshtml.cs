using ABC_STAFF_CLIENT.API;
using ABC_STAFF_CLIENT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_STAFF_CLIENT.Pages
{
    public class AccountsModel : PageModel
    {
        ApiService apiService=new ApiService();
        public IEnumerable<Account> accounts;

        public String sessionToken { get; set; }
        public async Task OnGet()
        {
            accounts=await apiService.GetAllAccounts();
            sessionToken = HttpContext.Session.GetString("token");
        }
    }
}
