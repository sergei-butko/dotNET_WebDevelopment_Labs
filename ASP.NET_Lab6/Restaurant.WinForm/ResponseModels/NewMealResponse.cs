using Restaurant.WinForm.FormModels;

namespace Restaurant.WinForm.ResponseModels
{
    public class NewMealResponse
    {
        public string MealName { get; set; } 
        public IngredientFormModel[] IngredientsToAdd { get; set; }
    }
}