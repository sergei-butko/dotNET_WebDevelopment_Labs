using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIngredientService _ingredientService;

        public IngredientController(IMapper mapper, IIngredientService ingredientService)
        {
            _mapper = mapper;
            _ingredientService = ingredientService;
        }

        [HttpGet("show_all_ingredients")]
        public IEnumerable<IngredientViewModel> ShowAllIngredients()
        {
            var ingredients = _ingredientService.GetAllIngredients();
            var allIngredients = _mapper.Map<IEnumerable<IngredientViewModel>>(ingredients);
            return allIngredients;
        }
    }
}