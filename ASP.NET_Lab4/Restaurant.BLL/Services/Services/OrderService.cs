using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.BLL.Services.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order, int> _orderRepository;
    private readonly IGenericRepository<MealForOrder, int> _mealForOrderRepository;

    public OrderService(IGenericRepository<Order, int> orderRepository,
        IGenericRepository<MealForOrder, int> mealForOrderRepository)
    {
        _orderRepository = orderRepository;
        _mealForOrderRepository = mealForOrderRepository;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _orderRepository.GetAll();
    }

    public async Task<Order> GetOrderDetails(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid ID");
        }

        var order = await _orderRepository.GetById(orderId);
        return order ?? throw new NullReferenceException("Order not found");
    }
    
    public IEnumerable<Meal> GetOrderMeals(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid Id");
        }

        var meals = _mealForOrderRepository.GetAll().AsQueryable()
            .Where(m => m.Order.Id == orderId).Select(m => m.Meal);
        return meals ?? throw new NullReferenceException("Order not found");
    }

    public void MakeNewOrder(string orderTitle, IEnumerable<Meal> meals)
    {
        var totalSum = 0.0;
        foreach (var meal in meals)
        {
            totalSum += meal.Price;
        }

        _orderRepository.Create(new Order
        {
            Title = orderTitle,
            TotalSum = totalSum,
            OrderTime = DateTime.Now
        });
        _orderRepository.Save();


        var order = _orderRepository.GetAll().FirstOrDefault(o => o.Title == orderTitle);
        foreach (var meal in meals)
        {
            _mealForOrderRepository.Create(new MealForOrder
            {
                Meal = meal,
                Order = order
            });
        }

        _mealForOrderRepository.Save();
    }

    public void ChangeOrderDetails(Order order)
    {
        _orderRepository.Update(order);
        _orderRepository.Save();
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

        _orderRepository.Save();
    }

    public async void ResolveOrder(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid ID");
        }

        var orderToUpdate = await _orderRepository.GetById(orderId);
        orderToUpdate.IsActive = 0;
        _orderRepository.Update(orderToUpdate);
        _orderRepository.Save();
    }
}