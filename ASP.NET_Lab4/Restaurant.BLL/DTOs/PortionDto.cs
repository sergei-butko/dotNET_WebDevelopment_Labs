namespace Restaurant.BLL.DTOs
{
    public class PortionDto
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string PortionName { get; set; }
        public double PricePer100g { get; set; }
        public double TotalSum { get; set; }
    }
}