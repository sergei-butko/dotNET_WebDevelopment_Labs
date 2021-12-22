using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;
using Restaurant.PL.ViewModels;

namespace Restaurant.PL.Controllers;

public class MealController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMealService _mealService;
    private readonly IIngredientService _ingredientService;

    public MealController(IMapper mapper, IMealService mealService, IIngredientService ingredientService)
    {
        _mapper = mapper;
        _mealService = mealService;
        _ingredientService = ingredientService;
    }

    public IActionResult ShowMenu()
    {
        var meals = _mealService.GetAllMeals();
        return View(_mapper.Map<IEnumerable<MealViewModel>>(meals));
    }

    public IActionResult ShowMealIngredients(int mealId)
    {
        var ingredients = _mealService.GetMealIngredients(mealId);
        return View(_mapper.Map<IEnumerable<IngredientViewModel>>(ingredients));
    }
    
    public IActionResult AddMeal()
    {
        var ingredients = _ingredientService.GetAllIngredients();
        return View(_mapper.Map<IEnumerable<IngredientViewModel>>(ingredients));
    }
    
    [HttpPost]
    public IActionResult NewMeal(string mealName, IEnumerable<int> ingredientsToAddId)
    {
        var ingredients = ingredientsToAddId.Select(id => _ingredientService.GetIngredient(id).Result).ToList();
        _mealService.AddNewMeal(mealName, _mapper.Map<IEnumerable<Ingredient>>(ingredients));
        return RedirectToAction("Index", "Home");
    }
}