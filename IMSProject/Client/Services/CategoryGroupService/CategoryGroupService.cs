using Microsoft.AspNetCore.Components;

namespace IMSProject.Client.Services.CategoryGroupService
{
    public class CategoryGroupService : ICategoryGroupService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public CategoryGroupService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<CategoryGroup> GroupsCategory { get; set; } = new List<CategoryGroup>();

        public async Task CreateCategoryGroup(CategoryGroup categoryGroup)
        {
            categoryGroup.CreatedAt = DateTime.Now.ToString();
            categoryGroup.CreatedBy = "User";
            categoryGroup.DomainStatus = true;
            var result = await _http.PostAsJsonAsync("api/cgroup", categoryGroup);
            await SetCategoryGroups(result);
        }
        private async Task SetCategoryGroups(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<CategoryGroup>>();
            GroupsCategory = response;
            _navigationManager.NavigateTo("groupcategories");
        }

        public async Task DeleteCategoryGroup(int id)
        {
            var result = await _http.DeleteAsync($"api/cgroup/{id}");
            await SetCategoryGroups(result);
        }

        public async Task<CategoryGroup> GetCategoryGroupById(int id)
        {
            var result = await _http.GetFromJsonAsync<CategoryGroup>($"api/cgroup/{id}");
            if (result != null)
                return result;
            throw new Exception("Category Group Not Found");
        }

        public async Task GetCategoryGroups()
        {
            var result = await _http.GetFromJsonAsync<List<CategoryGroup>>("api/cgroup");
            if(result != null)
                GroupsCategory = result;
        }

        public async Task UpdateCategoryGroup(CategoryGroup categoryGroup)
        {
            categoryGroup.UpdatedBy = "User";
            categoryGroup.UdatedAt = DateTime.Now.ToString();
            var result = await _http.PutAsJsonAsync($"api/cgroup/{categoryGroup.Id}", categoryGroup);
            await SetCategoryGroups(result);
        }
    }
}
