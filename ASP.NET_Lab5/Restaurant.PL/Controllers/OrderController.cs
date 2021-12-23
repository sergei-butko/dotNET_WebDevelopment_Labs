using System.Net;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;
using Restaurant.PL.ResponseModels;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public OrderController(IMapper mapper, IOrderService orderService)
    {
        _mapper = mapper;
        _orderService = orderService;
    }

    [HttpGet("orders_history")]
    public IEnumerable<OrderViewModel> ShowMenu()
    {
        var orders = _orderService.GetAllOrders();
        var ordersHistory = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        return ordersHistory;
    }

    [HttpGet("order_meals/{orderId}")]
    public IEnumerable<MealViewModel> GetOrderMeals(int orderId)
    {
        var orderMeals = _orderService.GetOrderMeals(orderId);
        var meals = _mapper.Map<IEnumerable<MealViewModel>>(orderMeals);
        return meals;
    }

    [HttpPost("make_order")]
    public HttpResponseMessage MakeOrder([FromBody] MakeOrderResponse response)
    {
        if (!ModelState.IsValid)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        var meals = _mapper.Map<IEnumerable<Meal>>(response.Meals);
        _orderService.MakeNewOrder(response.Order, meals);

        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}