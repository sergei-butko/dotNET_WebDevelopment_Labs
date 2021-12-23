using System.Collections.Generic;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IGenericRepository<Ingredient, int> _ingredientRepository;

        public IngredientService(IGenericRepository<Ingredient, int> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _ingredientRepository.GetAll();
        }
    }
}