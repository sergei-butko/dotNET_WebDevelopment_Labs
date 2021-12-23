using Restaurant.PL.ViewModels;

namespace Restaurant.PL.ResponseModels
{
    public class MakeOrderResponse
    {
        public string Order { get; set; } 
        public MealViewModel[] Meals { get; set; }
    }
}