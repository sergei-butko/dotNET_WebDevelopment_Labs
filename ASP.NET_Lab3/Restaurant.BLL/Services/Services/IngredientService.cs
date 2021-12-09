using System.Collections.Generic;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IGenericRepository<Ingredient> _ingredientRepository;

        public IngredientService(IGenericRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient GetIngredient(int ingredientId)
        {
            return _ingredientRepository.GetById(ingredientId);
        }
    }
}