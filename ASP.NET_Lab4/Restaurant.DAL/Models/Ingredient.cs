using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public double PricePerUnit { get; set; }
    }
}