using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Application
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = ServiceRegistrationExtension.RegisterServices();
            var restaurantService = serviceProvider.GetRequiredService<IRestaurantService>();

            restaurantService.StartProgram();
        }
    }

}