using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.PL.ViewModels;

namespace Restaurant.PL.Controllers
{
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

        [HttpGet("get_meals")]
        public IEnumerable<MealViewModel> GetAllMeals()
        {
            return _mapper.Map<IEnumerable<MealViewModel>>(_mealService.GetAllMeals());
        }
        
        [HttpGet("meal_portions/{mealId}")]
        public IEnumerable<PortionViewModel> GetMealPortions(int mealId)
        {
            return _mapper.Map<IEnumerable<PortionViewModel>>(_mealService.GetMealPortions(mealId));
        }

        [HttpGet("meal_details/{mealId}")]
        public MealViewModel GetOrderDetails(int mealId)
        {
            return _mapper.Map<MealViewModel>(_mealService.GetMealDetails(mealId));
        }
    }
}