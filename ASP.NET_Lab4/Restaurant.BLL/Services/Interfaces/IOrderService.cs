using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    Task<Order> GetOrderDetails(int orderId);
    IEnumerable<Meal> GetOrderMeals(int orderId);
    void MakeNewOrder(string orderTitle, IEnumerable<Meal> mealsToAdd);
    void ChangeOrderDetails(Order order);
    void CancelOrder(Order order);
    void ResolveOrder(int orderId);
}