namespace IMSProject.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> ClientCategories { get; set; }
        List<CategoryGroup> ClientCategoryGroups { get; set; }
        Task GetCategoryGroups();
        Task GetCategories();

        Task<Category> GetCategoryById(int id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
