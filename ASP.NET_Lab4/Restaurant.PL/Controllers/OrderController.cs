using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;
using Restaurant.PL.ViewModels;

namespace Restaurant.PL.Controllers;

public class OrderController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;
    private readonly IMealService _mealService;

    public OrderController(IOrderService orderService, IMapper mapper, IMealService mealService)
    {
        _orderService = orderService;
        _mapper = mapper;
        _mealService = mealService;
    }

    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAllOrders();
        return View(_mapper.Map<IEnumerable<OrderViewModel>>(orders));
    }
    
    public IActionResult GetOrderMeals(int orderId)
    {
        var meals = _orderService.GetOrderMeals(orderId);
        return View(_mapper.Map<IEnumerable<MealViewModel>>(meals));
    }

    public IActionResult MakeOrder()
    {
        var meals = _mealService.GetAllMeals();
        return View(_mapper.Map<IEnumerable<MealViewModel>>(meals));
    }

    [HttpPost]
    public IActionResult NewOrder(string orderTitle, IEnumerable<int> mealsToAddId)
    {
        var meals = mealsToAddId.Select(id => _mealService.GetMeal(id).Result).ToList();
        _orderService.MakeNewOrder(orderTitle, _mapper.Map<IEnumerable<Meal>>(meals));
        return RedirectToAction("Index", "Home");
    }
}