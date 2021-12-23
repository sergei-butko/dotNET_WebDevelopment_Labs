using Restaurant.WinForm.FormModels;

namespace Restaurant.WinForm.ResponseModels
{
    public class MakeOrderResponse
    {
        public string Order { get; set; }
        public MealFormModel[] Meals { get; set; }
    }
}