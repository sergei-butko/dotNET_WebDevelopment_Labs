using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Models
{
    public class PriceList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Meal Meal { get; set; }
        [Required, MaxLength(200)]
        public string PortionName { get; set; }
        [Required]
        public double TotalSum { get; set; }
    }
}