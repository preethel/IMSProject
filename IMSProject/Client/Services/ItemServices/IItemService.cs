namespace IMSProject.Client.Services.ItemServices
{
    public interface IItemService
    {
        List<Item> Items { get; set; }
        List<Category> Categories { get; set; }
        List<Unit> Units { get; set; }
        List<CategoryGroup> categoryGroups { get; set; }
        
        Task GetUnits();
        Task GetCategories();
        Task GetCategoryGroups();
        Task GetItems();

        Task<Item> GetSingleItem(int id);

        Task CreateItem(Item item);
        Task UpdateItem(Item item); 
        Task DeleteItem(int  id);
    }
}
