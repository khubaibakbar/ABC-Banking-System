using ABC_CUSTOMER_CLIENT.Models;
using ABC_CUSTOMER_CLIENT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_CUSTOMER_CLIENT.Pages
{
    public class TransferModel : PageModel
    {
        public String sessionToken { get; set; }

        private ApiService apiService = new ApiService();

        [BindProperty]
        public TransferUtil transferUtil { get; set; }

        public readonly ILogger<IndexModel> _logger;

        public TransferModel(ILogger<IndexModel> logger)
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
            transferUtil.sourceAccount = HttpContext.Session.GetString("token");
            String response = await apiService.makeTransfer(transferUtil);
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
