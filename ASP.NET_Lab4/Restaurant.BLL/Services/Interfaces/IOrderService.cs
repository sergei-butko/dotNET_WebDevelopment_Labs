using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderDetails(int orderId);
    }
}