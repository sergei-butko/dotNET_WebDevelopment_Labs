using System.Collections.Generic;
using System.Linq;
using Restaurant.BLL.DTOs;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class PortionService : IPortionService
    {
        private readonly IGenericRepository<PriceList> _priceListRepository;
        private readonly IGenericRepository<Meal> _mealRepository;

        public PortionService(IGenericRepository<PriceList> priceListRepository,
            IGenericRepository<Meal> mealRepository)
        {
            _priceListRepository = priceListRepository;
            _mealRepository = mealRepository;
        }
        
        public IEnumerable<PortionDto> GetAllPortions()
        {
            return _priceListRepository.GetAll()
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
    }
}