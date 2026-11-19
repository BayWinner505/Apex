using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<FoodBooking>? FoodBookings { get; set; }
        public List<MenuFoodItem>? MenuFoodItems { get; set; }

    }
}
