using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces;

public interface IIngredientService
{
    IEnumerable<Ingredient> GetAllIngredients();
    Task<Ingredient> GetIngredient(int ingredientId);
}