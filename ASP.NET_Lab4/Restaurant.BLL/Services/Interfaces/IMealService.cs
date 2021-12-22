using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces;

public interface IMealService
{
    IEnumerable<Meal> GetAllMeals();
    Task<Meal> GetMeal(int mealId);
    IEnumerable<Ingredient> GetMealIngredients(int mealId);
    void AddNewMeal(string mealName, IEnumerable<Ingredient> ingredients);
}