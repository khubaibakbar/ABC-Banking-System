using ABC_CUSTOMER_CLIENT.Models;
using ABC_CUSTOMER_CLIENT.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Text;

namespace ABC_CUSTOMER_CLIENT.Service
{
    public class ApiService
    {
        private HttpClient _httpClient;

        public PageModel pageModel { get; set; }
        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/v1/abc/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {

            var response = await _httpClient.GetAsync("accounts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<IEnumerable<Account>>(content);
                return accounts;
            }
            else
            {
                return Enumerable.Empty<Account>();
            }
        }

        public async Task<IEnumerable<DWTransaction>> GetDWTransactions()
        {

            var response = await _httpClient.GetAsync("dw");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dwTransactions = JsonConvert.DeserializeObject<IEnumerable<DWTransaction>>(content);
                return dwTransactions;
            }
            else
            {
                return Enumerable.Empty<DWTransaction>();
            }
        }

        public async Task<IEnumerable<Transfer>> GetTransfers()
        {

            var response = await _httpClient.GetAsync("transfers");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var transfers = JsonConvert.DeserializeObject<IEnumerable<Transfer>>(content);
                return transfers;
            }
            else
            {
                return Enumerable.Empty<Transfer>();
            }
        }

        public async Task<String> makeDeposit(DWUtil dwUtil)
        {
            var requestUri = "deposit";
            var response = await _httpClient.PostAsJsonAsync(requestUri, dwUtil);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent;
            }
            else
            {
                return responseContent;
            }
        }
        public async Task<String> makeWithdrawal(DWUtil dwUtil)
        {
            var requestUri = "withdraw";
            var response = await _httpClient.PostAsJsonAsync(requestUri, dwUtil);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent;
            }
            else
            {
                return responseContent;
            }
        }

        public async Task<String> makeTransfer(TransferUtil transferUtil)
        {
            var requestUri = "transfer";
            var response = await _httpClient.PostAsJsonAsync(requestUri, transferUtil);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent;
            }
            else
            {
                return responseContent;
            }
        }
    }
}
