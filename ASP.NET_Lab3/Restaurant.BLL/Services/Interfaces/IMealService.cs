using System.Collections.Generic;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IMealService
    {
        IEnumerable<Meal> GetAllMeals();
        Meal GetMeal(int mealId);
        IEnumerable<Ingredient> GetMealIngredients(int mealId);
        void AddNewMeal(string mealName, List<Ingredient> ingredients);
    }
}