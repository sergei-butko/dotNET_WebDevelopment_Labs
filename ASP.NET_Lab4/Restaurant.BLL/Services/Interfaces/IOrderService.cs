using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderDetails(int orderId);
        void MakeNewOrder(Order order);
        void ChangeOrderDetails(Order order);
        void CancelOrder(Order order);
        void ResolveOrder(int orderId);
    }
}