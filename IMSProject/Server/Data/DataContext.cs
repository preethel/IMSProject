using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<COFmodel> COFmodels { get; set; }
        //public DbSet<Detail> Details { get; set; }
    }
}
