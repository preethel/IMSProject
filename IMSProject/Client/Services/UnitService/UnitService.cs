using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UnitService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Unit> Unit { get; set; } = new List<Unit>();

        public async Task CreateUnit(Unit unit)
        {
            unit.DomainStatus = true;
            unit.CreatedAt = DateTime.Now.ToString();
            unit.CreatedBy = "User";
            var result = await _http.PostAsJsonAsync("api/units", unit);
            await SetUnits(result);
        }

        public async Task DeleteUnit(int id)
        {
            var result = await _http.DeleteAsync($"api/units/{id}");
            await SetUnits(result);
        }

        public async Task<Unit> GetUnitById(int id)
        {
            var result = await _http.GetFromJsonAsync<Unit>($"api/units/{id}");
            if (result != null)
                return result;
            throw new Exception("Unit Not Found");
        }

        public async Task GetUnits()
        {
            var result = await _http.GetFromJsonAsync<List<Unit>>("api/units");
            if (result != null)
                Unit = result;
        }

        public async Task RemoveUnit(Unit unit)
        {
            unit.UpdatedBy = "User";
            unit.UdatedAt = DateTime.Now.ToString();
            var result = await _http.PutAsJsonAsync($"api/units/remove/{unit.Id}", unit);
            await SetUnits(result);
        }

        public async Task UpdateUnit(Unit unit)
        {
            unit.UpdatedBy = "User";
            unit.UdatedAt = DateTime.Now.ToString();
            var result = await _http.PutAsJsonAsync($"api/units/{unit.Id}", unit);
            await SetUnits(result);
        }

        private async Task SetUnits(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Unit>>();
            Unit = response;
            _navigationManager.NavigateTo("measurementunits");
        }

    }
}
