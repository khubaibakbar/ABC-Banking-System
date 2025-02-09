using ABC_CUSTOMER_CLIENT.Models;
using ABC_CUSTOMER_CLIENT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_CUSTOMER_CLIENT.Pages
{
    public class DepositModel : PageModel
    {
        public String sessionToken { get; set; }

        private ApiService apiService = new ApiService();

        [BindProperty]
        public DWUtil DwUtil { get; set; }

        public readonly ILogger<IndexModel> _logger;

        public DepositModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            apiService.pageModel = this;
        }

        public void logError(string message)
        {
            _logger.LogInformation(message);    
        }

        public void OnGet()
        {
            sessionToken = HttpContext.Session.GetString("token");
        }
        public async Task<IActionResult> OnPost()
        {
            DwUtil.accountNumber= HttpContext.Session.GetString("token");
            String response = await apiService.makeDeposit(DwUtil);
            if (response.Equals("true"))
            {
                return RedirectToPage("/Account");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
