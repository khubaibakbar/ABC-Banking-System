using ABC_CUSTOMER_CLIENT.Models;
using ABC_CUSTOMER_CLIENT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_CUSTOMER_CLIENT.Pages
{
    public class IndexModel : PageModel
    {
        public  readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User user { get; set; }

        public String sessionToken { get; set; }

        private ApiService api = new ApiService();
            public  IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            sessionToken = HttpContext.Session.GetString("token");

        }

        public async Task<IActionResult> OnPost()
        {
            IEnumerable<Account> accounts=await api.GetAllAccounts();
            Boolean isLoggedIn = false;
            foreach(Account account in accounts)
            {
                if(account.Customer.Email==user.email && account.Customer.password == user.password)
                {
                    HttpContext.Session.SetString("token", account.AccountNumber);
                    isLoggedIn = true;
                }
            }
            ViewData["message"] = "Invalid email or password";
            if (isLoggedIn)
            {
                return RedirectToPage("/Account");
            }
            else
            {
                Response.WriteAsync("<script>alert('invalid login credentials'); window.open('/Accounts.cshtml','_self');</script>");
                return Page();
            }
            
            
        }
    }
}