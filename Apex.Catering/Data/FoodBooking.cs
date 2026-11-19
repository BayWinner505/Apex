using System.ComponentModel.DataAnnotations;
namespace Apex.Catering.Data
{
    public class FoodBooking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClientRefId { get; set; }

        [Required]
        public int NoOfguests { get; set; }

        [Required]
        public int MenuId { get; set; }

        public Menu Menu { get; set; }


    }
}
