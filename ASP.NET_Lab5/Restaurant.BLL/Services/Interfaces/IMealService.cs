using System.Collections.Generic;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces;

public interface IMealService
{
    IEnumerable<Meal> GetAllMeals();
    Meal GetMealDetails(int mealId);
}