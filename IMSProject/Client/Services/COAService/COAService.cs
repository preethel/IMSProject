using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.COAService
{
    public class COAService : ICOAService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public COAService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ChartOfAccount> ChartOfAccounts { get; set; } = new List<ChartOfAccount>();

        public async Task CreateCOA(ChartOfAccount chartOfAccount)
        {
            chartOfAccount.DomainStatus = true;
            chartOfAccount.CreatedAt = DateTime.Now.ToString();
            chartOfAccount.CreatedBy = "User";
            var result = await _http.PostAsJsonAsync("api/coa", chartOfAccount);
            await SetCOA(result);
        }

        public async Task DeleteCOA(int id)
        {
            var result = await _http.DeleteAsync($"api/coa/{id}");
            await SetCOA(result);
        }

        public async Task<ChartOfAccount> GetCOAById(int id)
        {
            var result = await _http.GetFromJsonAsync<ChartOfAccount>($"api/coa/{id}");
            if (result != null)
                return result;
            throw new Exception("Unit Not Found");
        }

        public async Task GetCOA()
        {
            var result = await _http.GetFromJsonAsync<List<ChartOfAccount>>("api/coa");
            if (result != null)
                ChartOfAccounts = result;
        }

        public async Task UpdateCOA(ChartOfAccount chartOfAccount)
        {
            chartOfAccount.UdatedAt = DateTime.Now.ToString();
            chartOfAccount.UpdatedBy = "User";
            var result = await _http.PutAsJsonAsync($"api/coa/{chartOfAccount.Id}", chartOfAccount);
            await SetCOA(result);
        }

        private async Task SetCOA(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ChartOfAccount>>();
            ChartOfAccounts = response;
            _navigationManager.NavigateTo("coas");
        }

        
    }
}
