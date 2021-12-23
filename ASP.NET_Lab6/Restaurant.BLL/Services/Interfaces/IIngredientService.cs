using System.Collections.Generic;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAllIngredients();
    }
}