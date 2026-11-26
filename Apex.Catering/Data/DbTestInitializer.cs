namespace Apex.Catering.Data
{
    public class DbTestInitializer
    {
        private readonly BookingsDbContext _context;
        public DbTestInitializer(BookingsDbContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            if (_context.FoodItems.Any())
            {
                return; // Db is already seeded from before
            }
            // Seed the database with test data                        
            var foodItems = new List<FoodItem>
            {
                new FoodItem { Name = "Chicken Curry", Description = "Spicy chicken curry with rice", Price = 12.99m },
                new FoodItem { Name = "Chicken Tikka Masala", Description = "A popular Indian dish made with marinated chicken cooked in a creamy tomato sauce.", Price = 12.99m },
                new FoodItem { Name = "Aloo Keema", Description = "A traditional Indian dish made with minced meat and potatoes, cooked with spices and herbs.", Price = 11.99m },
                new FoodItem { Name = "Gulaab Jamun", Description = "A popular Indian dessert made with deep-fried dough balls soaked in sugar syrup.", Price = 5.99m },
                new FoodItem { Name = "Beef Burger", Description = "Juicy beef burger with fries", Price = 9.99m },
                new FoodItem { Name = "Caesar Salad", Description = "Fresh Caesar salad with croutons", Price = 7.99m },
                new FoodItem { Name = "Margherita Pizza", Description = "Classic Margherita pizza with tomato sauce and mozzarella cheese", Price = 10.99m },
                new FoodItem { Name = "Chocolate Cake", Description = "Rich and moist chocolate cake with ganache frosting", Price = 6.99m },
                new FoodItem { Name = "Grilled Salmon", Description = "Freshly grilled salmon with lemon butter sauce", Price = 15.99m },
                new FoodItem { Name = "Vegetable Stir Fry", Description = "A quick and healthy dish made with a variety of fresh vegetables stir-fried in a savory sauce.", Price = 10.99m },
                new FoodItem { Name = "Spaghetti Bolognese", Description = "Classic Italian pasta dish with rich meat sauce", Price = 11.99m },
                new FoodItem { Name = "stracciatella Gelato", Description = "Italian gelato with chocolate shavings", Price = 4.99m },
                new FoodItem { Name = "Tiramisu", Description = "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream", Price = 6.99m },
                new FoodItem { Name = "Crepes Suzette", Description = "Thin French pancakes with orange sauce and Grand Marnier", Price = 7.99m },
            };
            _context.FoodItems.AddRange(foodItems);
            _context.SaveChanges();

            var menus = new List<Menu>
            {
                new Menu { Name = "Desserts" },
                new Menu { Name = "Italian Cuisine" },
                new Menu { Name = "Indian Cuisine" },
                new Menu { Name = "Western Cuisine" }
            };









        }


    }
}
