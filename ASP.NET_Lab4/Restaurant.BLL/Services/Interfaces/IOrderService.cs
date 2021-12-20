using System.Collections.Generic;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        void MakeNewOrder(string orderTitle, List<Meal> mealsToAdd);
        Order GetOrderDetails(int orderId);
        void ChangeOrderDetails(Order order);
        void CancelOrder(Order order);
        void ResolveOrder(int orderId);
    }
}