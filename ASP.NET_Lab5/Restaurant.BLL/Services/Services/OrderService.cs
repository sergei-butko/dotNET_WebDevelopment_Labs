using System;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order, int> _orderRepository;

    public OrderService(IGenericRepository<Order, int> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void MakeNewOrder(Order order)
    {
        _orderRepository.Create(order);
    }

    public Order GetOrderDetails(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid ID");
        }

        var order = _orderRepository.GetById(orderId);
        return order ?? throw new NullReferenceException("Order not found");
    }

    public void ChangeOrderDetails(Order order)
    {
        _orderRepository.Update(order);
    }

    public void CancelOrder(Order order)
    {
        if (order.IsActive == 1)
        {
            _orderRepository.Delete(order);
        }
        else
        {
            throw new ArgumentException("Order is already resolved!");
        }
    }

    public void ResolveOrder(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid ID");
        }

        var orderToUpdate = _orderRepository.GetById(orderId);
        orderToUpdate.IsActive = 0;
        _orderRepository.Update(orderToUpdate);
    }
}