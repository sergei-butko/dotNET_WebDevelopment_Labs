using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Models
{
    public class IngredientForMeal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Meal Meal { get; set; }
        [Required]
        public virtual Ingredient Ingredient { get; set; }
    }
}