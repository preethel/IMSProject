using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.ItemServices
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ItemService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<CategoryGroup> categoryGroups { get; set; } = new List<CategoryGroup>();

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/categories");
            if (result != null)
                Categories = result;
        }

        public async Task GetUnits()
        {
            var result = await _http.GetFromJsonAsync<List<Unit>>("api/units");
            if (result != null)
                Units = result;
        }

        public async Task GetItems()
        {
            var result = await _http.GetFromJsonAsync<List<Item>>("api/item");
            if(result != null)
                Items = result;
            
        }

        public async Task<Item> GetSingleItem(int id)
        {
            var result = await _http.GetFromJsonAsync<Item>($"api/item/{id}");
            if (result != null)
                return result;
            throw new Exception("Not found");
        }

        public async Task CreateItem(Item item)
        {
            item.DomainStatus = true;
            item.CreatedAt = DateTime.Now.ToString();
            item.CreatedBy = "User";
            var result = await _http.PostAsJsonAsync("api/item", item);
            await SetItems(result);
        }

        private async Task SetItems(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Item>>();

            Items = response;
            _navigationManager.NavigateTo("items");
        }

        public async Task DeleteItem(int id)
        {
            var result = await _http.DeleteAsync($"/api/item/{id}");

            await SetItems(result);
        }

        public async Task UpdateItem(Item item)
        {
            item.UpdatedBy = "User";
            item.UdatedAt = DateTime.Now.ToString();
            var result = await _http.PutAsJsonAsync($"/api/item/{item.Id}", item);

            await SetItems(result);
        }

        public async Task GetCategoryGroups()
        {
            var result = await _http.GetFromJsonAsync<List<CategoryGroup>>("api/cgroup");
            if (result != null)
                categoryGroups = result;
        }
    }
}
