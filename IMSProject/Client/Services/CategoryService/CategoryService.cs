using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public List<Category> ClientCategories { get; set; } = new List<Category>();
        public List<CategoryGroup> ClientCategoryGroups { get ; set ; } = new List<CategoryGroup>();

        public CategoryService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task CreateCategory(Category category)
        {
            var result = await _http.PostAsJsonAsync("api/categories", category);
            await SetCategories(result);
        }
        private async Task SetCategories(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Category>>();
            ClientCategories = response;
            _navigationManager.NavigateTo("categories");
        }
        public async Task DeleteCategory(int id)
        {
            var result = await _http.DeleteAsync($"api/categories/{id}");
            await SetCategories(result);
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/categories");
            if (result != null)
                ClientCategories = result;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = await _http.GetFromJsonAsync<Category>($"api/categories/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetCategoryGroups()
        {
            var result = await _http.GetFromJsonAsync<List<CategoryGroup>>("api/cgroup");
            if (result != null)
                ClientCategoryGroups = result;
        }

        public async Task UpdateCategory(Category category)
        {
            var result = await _http.PutAsJsonAsync($"api/categories/{category.Id}", category);
            await SetCategories(result);
        }
    }
}
