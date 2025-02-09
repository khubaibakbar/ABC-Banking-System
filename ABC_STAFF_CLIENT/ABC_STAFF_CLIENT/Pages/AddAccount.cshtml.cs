using ABC_STAFF_CLIENT.API;
using ABC_STAFF_CLIENT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http.Headers;

namespace ABC_STAFF_CLIENT.Pages
{
    public class AddAccountModel : PageModel
    {
        ApiService api = new ApiService();
        public string? sessionToken { get; set; }

        public async void OnGet()
        {
            //IEnumerable<DWTransaction> transactions = await api.GetDWTransactions();
            //Console.WriteLine(transactions.ToList().ToString());
            sessionToken = HttpContext.Session.GetString("token");
        }

        [BindProperty]
        public Customer customer { get; set; }
        public async Task<IActionResult> OnPost() {
            String password = generatePassword(8);
            Account account=new Account();
            customer.password=password;
            account.Customer = customer;
            account.Branch = customer.Branch;

            Console.WriteLine(customer.Names);

            //send to API
            
            var createdAccount=await api.AddAccount(account);
            if(createdAccount != null)
            {

                //Response.WriteAsync("<script>alert('Account created succesfully')</script>");
                ViewData["AlertMessage"] = "Account created successfully";
                return RedirectToPage("/Accounts");
            }
            else
            {
                await Response.WriteAsync("<script>alert('ERROR!! creating account failed')</script>");
                return Page();
            }

        }

        public  string generatePassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
