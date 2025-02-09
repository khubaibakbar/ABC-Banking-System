using ABC_STAFF_CLIENT.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ABC_STAFF_CLIENT.API
{
    public class ApiService
    {
        private HttpClient _httpClient;
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
        public async Task<Account> AddAccount(Account account)
        {
            var requestUri = "account";
            
            AccountUtil accountUtil = new AccountUtil(account);

            var jsonAccount = JsonConvert.SerializeObject(accountUtil);
            var content = new StringContent(jsonAccount, Encoding.UTF8, "application/json");


            //var response = await _httpClient.PostAsync(requestUri, content);
            var response=await _httpClient.PostAsJsonAsync(requestUri, accountUtil);
            //var errorContent = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var errorContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var createdAccount = JsonConvert.DeserializeObject<Account>(errorContent);
                    return createdAccount;
                }catch(JsonException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<HttpResponseMessage> AddAccountRawJSon(Account account)
        {
            var requestUri = "account";

            AccountUtil accountUtil = new AccountUtil(account);

            var jsonAccount = JsonConvert.SerializeObject(accountUtil);
            var content = new StringContent(accountUtil.ToString(), Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync(requestUri, content);
            //var response=await _httpClient.PostAsJsonAsync(requestUri, accountUtil);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return response;
            }
            else
            {
                return response; 
            }
        }

    }
}
