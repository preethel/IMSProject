namespace IMSProject.Client.Services.CategoryGroupService
{
    public interface ICategoryGroupService
    {
        List<CategoryGroup> GroupsCategory { get; set; }

        Task GetCategoryGroups();

        Task<CategoryGroup> GetCategoryGroupById(int id);

        Task CreateCategoryGroup(CategoryGroup categoryGroup);

        Task UpdateCategoryGroup(CategoryGroup categoryGroup);

        Task DeleteCategoryGroup(int id);
    }
}
