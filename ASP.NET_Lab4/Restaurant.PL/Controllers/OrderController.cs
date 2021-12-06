using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL.Controllers
{
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

        [HttpGet("order_details/{orderId}")]
        public OrderViewModel GetOrderDetails(int orderId)
        {
            return _mapper.Map<OrderViewModel>(_orderService.GetOrderDetails(orderId));
        }
    }
}