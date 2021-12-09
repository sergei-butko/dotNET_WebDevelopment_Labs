using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class MealService : IMealService
    {
        private readonly IGenericRepository<Meal> _mealRepository;
        private readonly IGenericRepository<Ingredient> _ingredientRepository;
        private readonly IGenericRepository<IngredientForMeal> _ingredientForMealRepository;

        public MealService(IGenericRepository<Meal> mealRepository, IGenericRepository<Ingredient> ingredientRepository,
            IGenericRepository<IngredientForMeal> ingredientForMealRepository)
        {
            _mealRepository = mealRepository;
            _ingredientRepository = ingredientRepository;
            _ingredientForMealRepository = ingredientForMealRepository;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _mealRepository.GetAll();
        }
        
        public Meal GetMeal(int mealId)
        {
            return _mealRepository.GetById(mealId);
        }
        
        public IEnumerable<Ingredient> GetMealIngredients(int mealId)
        {
            if (mealId <= 0)
            {
                throw new ArgumentException("Invalid ID");
            }

            var ingredients = _ingredientForMealRepository.GetAll()
                .Where(e => e.Meal.Id == mealId)
                .Join(_ingredientRepository.GetAll(),
                    ingredientForMeal => ingredientForMeal.Ingredient.Id,
                    ingredient => ingredient.Id,
                    (ingredientForMeal, ingredient) => ingredient);

            return ingredients ?? throw new NullReferenceException("Meal not found");
        }

        public void AddNewMeal(string mealName, List<Ingredient> ingredients)
        {
            var totalSum = 0.0;
            foreach (var ingredient in ingredients)
            {
                totalSum += ingredient.PricePerUnit;
            }
            _mealRepository.Create(new Meal 
            {
                Name = mealName,
                Price = totalSum
            });

            var meal = _mealRepository.GetAll().FirstOrDefault(m => m.Name == mealName);
            foreach (var ingredient in ingredients)
            {
                _ingredientForMealRepository.Create(new IngredientForMeal
                {
                    Ingredient = ingredient,
                    Meal = meal
                });
            }
        }
    }
}