using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Repositories.Repositories;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.BLL.Services.Services;

namespace Restaurant.Application
{
    public static class ServiceRegistrationExtension
    {
        private static readonly IConfigurationRoot Configuration = 
            new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        public static ServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddSingleton<IIngredientService, IngredientService>()
                .AddSingleton<IMealService, MealService>()
                .AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IRestaurantService, RestaurantService>()
                .AddDbContext<DAL.ApplicationContext>(options => options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();
        }
    }
}