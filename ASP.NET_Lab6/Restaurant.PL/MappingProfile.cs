using Restaurant.BLL.DTOs;
using Restaurant.DAL.Models;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<Meal, MealViewModel>();
            CreateMap<PortionDto, PortionViewModel>();

            CreateMap<OrderViewModel, Order>();
        }
    }
}