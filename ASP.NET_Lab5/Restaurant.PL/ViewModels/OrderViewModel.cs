using System;

namespace Restaurant.PL.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double TotalSum { get; set; }
        public DateTime OrderTime { get; set; }
        public int IsActive { get; set; }
    }
}