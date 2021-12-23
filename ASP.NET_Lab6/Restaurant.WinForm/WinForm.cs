using System;
using System.Windows.Forms;

namespace Restaurant.WinForm
{
    public partial class WinForm : Form
    {
        private readonly ApiHelper _apiHelper = new ApiHelper();

        public WinForm()
        {
            InitializeComponent();
        }

        /* --- GET --- */
        private async void btn_show_menu_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.ShowMenu();
            text_result.Text = _apiHelper.ShowAsJson(response);
        }

        private async void btn_all_orders_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.ShowAllOrders();
            text_result.Text = _apiHelper.ShowAsJson(response);
        }

        private async void btn_meal_ingredients_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetMealIngredients(text_meal_id.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }

        private async void btn_order_meals_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.GetOrderMeals(text_order_id.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }

        /* --- POST --- */
        private async void btn_new_meal_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.AddNewMeal(text_meal_name.Text, text_new_meal.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }

        private async void btn_make_order_Click(object sender, EventArgs e)
        {
            var response = await _apiHelper.MakeOrder(text_order_title.Text, text_make_order.Text);
            text_result.Text = _apiHelper.ShowAsJson(response);
        }
    }
}
