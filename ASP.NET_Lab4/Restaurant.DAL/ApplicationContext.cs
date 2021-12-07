using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Models;

namespace Restaurant.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<IngredientForMeal> IngredientsForMeals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MealForOrder> MealsForOrders { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
    }
}