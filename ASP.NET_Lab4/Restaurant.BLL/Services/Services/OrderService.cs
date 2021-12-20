using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<MealForOrder> _mealForOrderRepository;

        public OrderService(IGenericRepository<Order> orderRepository,
            IGenericRepository<MealForOrder> mealForOrderRepository)
        {
            _orderRepository = orderRepository;
            _mealForOrderRepository = mealForOrderRepository;
        }

        public void MakeNewOrder(string orderTitle, List<Meal> meals)
        {
            var totalSum = 0.0;
            foreach (var meal in meals)
            {
                totalSum += meal.Price;
            }
            _orderRepository.Create(new Order 
            {
                Title = orderTitle,
                TotalSum = totalSum
            });

            var order = _orderRepository.GetAll().FirstOrDefault(o => o.Title == orderTitle);
            foreach (var meal in meals)
            {
                _mealForOrderRepository.Create(new MealForOrder
                {
                    Meal = meal,
                    Order = order
                });
            }
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
}