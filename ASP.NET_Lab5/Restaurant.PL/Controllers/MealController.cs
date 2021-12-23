using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;
using Restaurant.PL.ResponseModels;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMealService _mealService;

    public MealController(IMapper mapper, IMealService mealService)
    {
        _mapper = mapper;
        _mealService = mealService;
    }

    [HttpGet("show_menu")]
    public IEnumerable<MealViewModel> ShowMenu()
    {
        var meals = _mealService.GetAllMeals();
        var menu = _mapper.Map<IEnumerable<MealViewModel>>(meals);
        return menu;
    }

    [HttpGet("meal_ingredients/{mealId}")]
    public IEnumerable<IngredientViewModel> ShowMealIngredients(int mealId)
    {
        var mealIngredients = _mealService.GetMealIngredients(mealId);
        var ingredients = _mapper.Map<IEnumerable<IngredientViewModel>>(mealIngredients);
        return ingredients;
    }

    [HttpPost("new_meal")]
    public HttpResponseMessage NewMeal([FromBody] NewMealResponse response)
    {
        if (!ModelState.IsValid)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var ingredients = _mapper.Map<IEnumerable<Ingredient>>(response.Ingredients);
        _mealService.AddNewMeal(response.Meal, ingredients);

        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}