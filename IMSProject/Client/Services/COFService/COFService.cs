using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.COFService
{
    public class COFService : ICOFService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public COFService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<COFmodel> COFmodels { get; set; } = new List<COFmodel>();

        public async Task CreateCOF(COFmodel cOFmodel)
        {
            cOFmodel.DomainStatus = true;
            cOFmodel.CreatedAt = DateTime.Now.ToString();
            cOFmodel.CreatedBy = "User";
            var result = await _http.PostAsJsonAsync("api/cof", cOFmodel);
            await SetCOF(result);
        }

        public async Task DeleteCOF(int id)
        {
            var result = await _http.DeleteAsync($"api/cof/{id}");
            await SetCOF(result);
        }

        public async Task<COFmodel> GetCOFById(int id)
        {
            var result = await _http.GetFromJsonAsync<COFmodel>($"api/cof/{id}");
            if (result != null)
                return result;
            throw new Exception("Unit Not Found");
        }

        public async Task GetCOF()
        {
            var result = await _http.GetFromJsonAsync<List<COFmodel>>("api/cof");
            if (result != null)
                COFmodels = result;
        }

        public async Task UpdateCOF(COFmodel cOFmodel)
        {
            cOFmodel.UdatedAt = DateTime.Now.ToString();
            cOFmodel.UpdatedBy = "User";
            var result = await _http.PutAsJsonAsync($"api/cof/{cOFmodel.Id}", cOFmodel);
            await SetCOF(result);
        }

        private async Task SetCOF(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<COFmodel>>();
            COFmodels = response;
            _navigationManager.NavigateTo("cofs");
        }

        
    }
}
