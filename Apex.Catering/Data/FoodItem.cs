using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<MenuFoodItem>? MenuFoodItems { get; set; }
    }
}
