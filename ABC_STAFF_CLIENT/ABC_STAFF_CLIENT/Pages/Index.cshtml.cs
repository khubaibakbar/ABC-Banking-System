using ABC_STAFF_CLIENT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_STAFF_CLIENT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User user { get; set; }

        public String sessionToken { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            sessionToken = HttpContext.Session.GetString("token");
        }
        public async Task<IActionResult> OnPost()
        {
            if(user.username!="admin" && user.password != "admin1234")
            {
                await Response.WriteAsync("<script>alert('Incorrect username or password')</script>");
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("token", user.username);
                return RedirectToPage("/Accounts");
            }
        }
    }
}