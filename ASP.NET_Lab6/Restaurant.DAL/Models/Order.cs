using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(1000)]
        public string Title { get; set; }
        [Required]
        public double TotalSum { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public int IsActive { get; set; } = 1;
    }
}