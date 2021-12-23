using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Restaurant.WinForm
{
    public class ApiHelper
    {
        private readonly string _baseUrl = "https://localhost:5001";
        private readonly HttpClient _client = new HttpClient();

        /* --- GET --- */
        public async Task<string> ShowMenu()
        {
            var response = await _client.GetAsync($"{_baseUrl}/meal/show_menu");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        public async Task<string> ShowAllOrders()
        {
            var response = await _client.GetAsync($"{_baseUrl}/order/orders_history");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        public async Task<string> GetMealIngredients(string mealId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/meal/meal_ingredients/{mealId}");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        public async Task<string> GetOrderMeals(string orderId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/order/order_meals/{orderId}");
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        /* --- POST --- */
        public async Task<string> AddNewMeal(string mealName, string mealIngredients)
        {
            var inputData = new Dictionary<string, string>
            {
                ["mealName"] = mealName,
                ["mealIngredients"] = mealIngredients
            };
            var json = JsonConvert.SerializeObject(inputData);
            var input = new StringContent(json, Encoding.UTF8);

            var response = await _client.PostAsync($"{_baseUrl}/meal/new_meal", input);
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        public async Task<string> MakeOrder(string orderTitle, string orderMeals)
        {
            var inputData = new Dictionary<string, string>
            {
                ["orderTitle"] = orderTitle,
                ["orderMeals"] = orderMeals
            };
            var json = JsonConvert.SerializeObject(inputData);
            var input = new StringContent(json, Encoding.UTF8);

            var response = await _client.PostAsync($"{_baseUrl}/order/make_order", input);
            var content = await response.Content.ReadAsStringAsync();
            return content ?? string.Empty;
        }

        /* --- JSON Converter --- */
        public string ShowAsJson(string content)
        {
            var parseJson = JToken.Parse(content);
            return parseJson.ToString(Formatting.Indented);
        }
    }
}
