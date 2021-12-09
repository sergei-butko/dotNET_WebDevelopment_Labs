using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.DAL.Models;

namespace Restaurant.Application
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMealService _mealService;
        private readonly IOrderService _orderService;

        public RestaurantService(IIngredientService ingredientService,
            IMealService mealService, IOrderService orderService)
        {
            _ingredientService = ingredientService;
            _mealService = mealService;
            _orderService = orderService;
        }

        public void StartProgram()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~ Lab_3. Variant_1. Restaurant Application ~~~~~~~~~~~~~~~~");
            
            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Show menu\t  2. Make own meal");
                Console.WriteLine("3. Make order\t  4. Close Program");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Choose What to Do: ");
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            var meals = GetMenu();
                            ShowMealsIngredients(meals);
                            break;
                        case 2:
                            MakeMeal();
                            break;
                        case 3:
                            MakeOrder();
                            break;
                        case 4:
                            alive = false;
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.ReadKey();
        }

        private Meal[] GetMenu()
        {
            var meals = _mealService.GetAllMeals().ToArray();
            if (meals == null)
            {
                throw new NullReferenceException("No meals was found");
            }
            
            Console.WriteLine("ID    Price    Name");
            foreach (var meal in meals)
            {
                Console.WriteLine($"{meal.Id} - \t{meal.Price} - {meal.Name}");
            }

            return meals;
        }

        private void ShowMealsIngredients(Meal[] meals)
        {
            var alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nDo you want to see some meal ingredients?");
                Console.WriteLine("1. Yes\t 2. No");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Your choice: ");
                    var command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            Console.Write("Enter meal ID: ");
                            var mealId = Convert.ToInt32(Console.ReadLine());
                            if (mealId > 0 && mealId <= meals.Length)
                            {
                                DisplayMealIngredients(mealId);
                            }
                            else
                            {
                                throw new ArgumentException("ID is incorrect");
                            }
                            break;
                        case 2:
                            alive = false;
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        private void DisplayMealIngredients(int mealId)
        {
            var ingredients = _mealService.GetMealIngredients(mealId);
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($" - {ingredient.Name}");
            }
        }

        private void MakeMeal()
        {
            Console.Write("\nEnter meal name: ");
            var mealName = Console.ReadLine();
            if (mealName == null && mealName == "")
            {
                throw new ArgumentException("Meal name not typed");
            }
            
            Console.WriteLine("\n--- Choose meal ingredients ---");
            ShowAllIngredients();
            var ingredientsToAdd = new List<Ingredient>();
            var alive = true;
            while (alive)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n(to stop adding ingredients enter 0)\n");
                    Console.Write("Add ingredient: ");
                    var ingredientId = Convert.ToInt32(Console.ReadLine());
                    if (ingredientId == 0)
                    {
                        alive = false;
                    }
                    else
                    {
                        if (ingredientId > 0)
                        {
                            var ingredientToAdd = _ingredientService.GetIngredient(ingredientId);
                            if (ingredientToAdd != null)
                            {
                                ingredientsToAdd.Add(ingredientToAdd);
                            }
                            else
                            {
                                throw new NullReferenceException("Ingredient not found");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid ID");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            _mealService.AddNewMeal(mealName, ingredientsToAdd);
        }
        
        private void ShowAllIngredients()
        {
            Console.WriteLine("ID   Name     Price");
            var ingredients = _ingredientService.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Id} - {ingredient.Name} \t- {ingredient.PricePerUnit}");
            }
        }

        private void MakeOrder()
        {
            Console.Write("\nEnter order title: ");
            var orderTitle = Console.ReadLine();
            if (orderTitle == null && orderTitle == "")
            {
                throw new ArgumentException("Order title not typed");
            }
            
            Console.WriteLine("\n--- Choose meals ---");
            GetMenu();
            var mealsToAdd = new List<Meal>();
            var alive = true;
            while (alive)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n(to stop adding meals enter 0)\n");
                    Console.Write("Add meal: ");
                    var mealId = Convert.ToInt32(Console.ReadLine());
                    if (mealId == 0)
                    {
                        alive = false;
                    }
                    else
                    {
                        if (mealId > 0)
                        {
                            var mealToAdd = _mealService.GetMeal(mealId);
                            if (mealToAdd != null)
                            {
                                mealsToAdd.Add(mealToAdd);
                            }
                            else
                            {
                                throw new NullReferenceException("Meal not found");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid ID");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            _orderService.MakeNewOrder(orderTitle, mealsToAdd);
        }
    }
}