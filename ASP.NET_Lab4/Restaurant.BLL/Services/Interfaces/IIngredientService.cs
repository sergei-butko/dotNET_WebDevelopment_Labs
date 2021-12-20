using System.Collections.Generic;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IIngredientService
    {
        public IEnumerable<Ingredient> GetAllIngredients();
        public Ingredient GetIngredient(int ingredientId);
    }
}