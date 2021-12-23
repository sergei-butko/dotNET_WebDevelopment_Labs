using Restaurant.PL.ViewModels;

namespace Restaurant.PL.ResponseModels;

public class NewMealResponse
{
    public string Meal { get; set; }
    public IngredientViewModel[] Ingredients { get; set; }
}