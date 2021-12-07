using System.Collections.Generic;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IMealService
    {
        IEnumerable<Meal> GetAllMeals();
        IEnumerable<PortionDto> GetMealPortions(int mealId);
        Meal GetMealDetails(int mealId);
    }
}