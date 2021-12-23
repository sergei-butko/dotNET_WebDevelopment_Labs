using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services;

public class MealService : IMealService
{
    private readonly IGenericRepository<Meal, int> _mealRepository;
    private readonly IGenericRepository<Ingredient, int> _ingredientRepository;
    private readonly IGenericRepository<IngredientForMeal, int> _ingredientForMealRepository;

    public MealService(IGenericRepository<Meal, int> mealRepository,
        IGenericRepository<Ingredient, int> ingredientRepository,
        IGenericRepository<IngredientForMeal, int> ingredientForMealRepository)
    {
        _mealRepository = mealRepository;
        _ingredientRepository = ingredientRepository;
        _ingredientForMealRepository = ingredientForMealRepository;
    }

    public IEnumerable<Meal> GetAllMeals()
    {
        return _mealRepository.GetAll();
    }

    public async Task<Meal> GetMeal(int mealId)
    {
        return await _mealRepository.GetById(mealId);
    }

    public IEnumerable<Ingredient> GetMealIngredients(int mealId)
    {
        if (mealId <= 0)
        {
            throw new ArgumentException("Invalid Id");
        }

        var ingredients = _ingredientForMealRepository.GetAll().AsQueryable()
            .Where(i => i.Meal.Id == mealId).Select(i => i.Ingredient);
        return ingredients ?? throw new NullReferenceException("Meal not found");
    }

    public void AddNewMeal(string mealName, IEnumerable<Ingredient> ingredients)
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
        _mealRepository.Save();

        var meal = _mealRepository.GetAll().AsQueryable().FirstOrDefault(m => m.Name == mealName);
        foreach (var ingredient in ingredients)
        {
            _ingredientForMealRepository.Create(new IngredientForMeal
            {
                Ingredient = ingredient,
                Meal = meal
            });
        }

        _ingredientForMealRepository.Save();
    }
}