using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class MenuFoodItem
    {
        [Required]
        public int MenuId { get; set; }

        [Required]
        public int FoodItemId { get; set; }

        
        public List<FoodItem>? FoodItems { get; set; }
        public Menu Menu { get; set; }

    }
}
