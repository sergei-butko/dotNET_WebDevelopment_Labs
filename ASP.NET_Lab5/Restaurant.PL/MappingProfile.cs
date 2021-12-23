using Restaurant.DAL.Models;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientViewModel>();
        CreateMap<Meal, MealViewModel>();
        CreateMap<Order, OrderViewModel>();

        CreateMap<IngredientViewModel, Ingredient>();
        CreateMap<MealViewModel, Meal>();
        CreateMap<OrderViewModel, Order>();
    }
}