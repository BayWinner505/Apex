using Microsoft.EntityFrameworkCore;

namespace Apex.Catering.Data
{
    public class BookingsDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }

        private string DbPath { get; set; } = string.Empty;
        // Constructor to set-up the database path & name
        public BookingsDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "apex.Catering.db");
        }
        // OnConfiguring to specify that the SQLite database engine will be used
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MenuFoodItem>()
                .HasKey(m => new { m.MenuId, m.FoodItemId });

            builder.Entity<MenuFoodItem>()
                .HasOne(mfi => mfi.Menu)
                .WithMany(m => m.MenuFoodItems)
                .HasForeignKey(mfi => mfi.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodBooking>()
                .HasOne(fb => fb.Menu)
                .WithMany(m => m.FoodBookings)            
                .HasForeignKey(fb => fb.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            // Insert sedd data for FoodItems
            builder.Entity<FoodItem>().HasData(
                new FoodItem { Id = 1, Name = "Chicken Tikka Masala", Description = "A popular Indian dish made with marinated chicken cooked in a creamy tomato sauce.", Price = 12.99m },
                new FoodItem { Id = 2, Name = "Beef Stroganoff", Description = "A Russian dish made with sautéed pieces of beef served in a sauce with sour cream.", Price = 14.99m },
                new FoodItem { Id = 3, Name = "Vegetable Stir Fry", Description = "A quick and healthy dish made with a variety of fresh vegetables stir-fried in a savory sauce.", Price = 10.99m }
            );


        }

    }

}   
