using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryGroup>().HasData(
                new CategoryGroup
                {
                    Id = 1,
                    Title = "IMS-1"
                },
                new CategoryGroup
                {
                    Id = 2,
                    Title = "IMS-2"
                }
                );



                //modelBuilder.Entity<Category>().HasData(
                //new Category
                //{
                //    Id = 1,
                //    Title = "Chaal",
                //    Description = ""
                //},
                //new Category
                //{
                //    Id = 2,
                //    Title = "Daal",
                //    Description = ""
                //},
                //new Category
                //{
                //    Id = 3,
                //    Title = "Tel",
                //    Description = ""
                //}
                //);

                //modelBuilder.Entity<Unit>().HasData(
                //new Unit
                //{
                //    Id = 1,
                //    Type = "kg",
                //    Description = "Kilogram"
                //},
                //new Unit
                //{
                //    Id = 2,
                //    Type = "L",
                //    Description = "Liter"
                //}

                //);

                //modelBuilder.Entity<Item>().HasData(
                //new Item
                //{
                //    Id = 1,
                //    Title = "Athais",
                //    Description = "NotunChaal",
                //    Ammount = 10000,
                //    Quantity = 500,
                //    SellingPrice = 70,
                //    CategoryId = 1,
                //    UnitId = 1
                //},
                //new Item
                //{
                //    Id = 2,
                //    Title = "Miniket",
                //    Description = "NotunChaal",
                //    Ammount = 10000,
                //    Quantity = 500,
                //    SellingPrice = 70,
                //    CategoryId = 1,
                //    UnitId = 1
                //},
                //new Item
                //{
                //    Id = 3,
                //    Title = "Rupchada",
                //    Description = "Soyabin",
                //    Ammount = 10000,
                //    Quantity = 500,
                //    SellingPrice = 60,
                //    CategoryId = 3,
                //    UnitId = 2
                //},
                //new Item
                //{
                //    Id = 4,
                //    Title = "Moshur",
                //    Description = "ACI",
                //    Ammount = 10000,
                //    Quantity = 500,
                //    SellingPrice = 90,
                //    CategoryId = 3,
                //    UnitId = 2 
                //}
                //);
        }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
