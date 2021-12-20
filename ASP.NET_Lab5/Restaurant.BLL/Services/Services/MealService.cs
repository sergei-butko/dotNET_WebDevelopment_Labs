using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services;

public class MealService : IMealService
{
    private readonly IGenericRepository<Meal, int> _mealRepository;

    public MealService(IGenericRepository<Meal, int> mealRepository)
    {
        _mealRepository = mealRepository;
    }

    public IEnumerable<Meal> GetAllMeals()
    {
        return _mealRepository.GetAll();
    }

    public Meal GetMealDetails(int mealId)
    {
        if (mealId <= 0)
        {
            throw new ArgumentException("Invalid ID");
        }

        var meal = _mealRepository.GetById(mealId);
        return meal ?? throw new NullReferenceException("Meal not found");
    }
}