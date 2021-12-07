using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.BLL.DTOs;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class MealService : IMealService
    {
        private readonly IGenericRepository<Meal> _mealRepository;
        private readonly IGenericRepository<PriceList> _priceListRepository;

        public MealService(IGenericRepository<Meal> mealRepository, IGenericRepository<PriceList> priceListRepository)
        {
            _mealRepository = mealRepository;
            _priceListRepository = priceListRepository;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _mealRepository.GetAll();
        }

        public IEnumerable<PortionDto> GetMealPortions(int mealId)
        {
            return _priceListRepository.GetAll()
                .Where(p => p.Meal.Id == mealId)
                .Join(_mealRepository.GetAll(),
                    p => p.Meal.Id,
                    m => m.Id,
                    (p, m) => new PortionDto
                    {
                        Id = p.Id,
                        MealName = m.Name,
                        PortionName = p.PortionName,
                        PricePer100g = m.PricePer100g,
                        TotalSum = p.TotalSum
                    });
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
}