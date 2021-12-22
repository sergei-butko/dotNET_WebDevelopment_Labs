using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Models;

public class MealForOrder
{
    [Key]
    public int Id { get; set; }
    [Required]
    public virtual Order Order { get; set; }
    [Required]
    public virtual Meal Meal { get; set; }
}