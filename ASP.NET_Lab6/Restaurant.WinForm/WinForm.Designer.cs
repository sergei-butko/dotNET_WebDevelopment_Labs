namespace Restaurant.WinForm
{
    partial class WinForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.text_result = new System.Windows.Forms.RichTextBox();
            this.btn_show_menu = new System.Windows.Forms.Button();
            this.btn_all_orders = new System.Windows.Forms.Button();
            this.btn_meal_ingredients = new System.Windows.Forms.Button();
            this.btn_order_meals = new System.Windows.Forms.Button();
            this.text_meal_id = new System.Windows.Forms.TextBox();
            this.text_order_id = new System.Windows.Forms.TextBox();
            this.btn_new_meal = new System.Windows.Forms.Button();
            this.btn_make_order = new System.Windows.Forms.Button();
            this.text_new_meal = new System.Windows.Forms.RichTextBox();
            this.text_make_order = new System.Windows.Forms.RichTextBox();
            this.text_meal_name = new System.Windows.Forms.TextBox();
            this.text_order_title = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_result
            // 
            this.text_result.Location = new System.Drawing.Point(728, 141);
            this.text_result.Name = "text_result";
            this.text_result.Size = new System.Drawing.Size(628, 946);
            this.text_result.TabIndex = 0;
            this.text_result.Text = "";
            // 
            // btn_show_menu
            // 
            this.btn_show_menu.Location = new System.Drawing.Point(12, 26);
            this.btn_show_menu.Name = "btn_show_menu";
            this.btn_show_menu.Size = new System.Drawing.Size(693, 87);
            this.btn_show_menu.TabIndex = 1;
            this.btn_show_menu.Text = "Show menu";
            this.btn_show_menu.UseVisualStyleBackColor = true;
            this.btn_show_menu.Click += new System.EventHandler(this.btn_show_menu_Click);
            // 
            // btn_all_orders
            // 
            this.btn_all_orders.Location = new System.Drawing.Point(728, 26);
            this.btn_all_orders.Name = "btn_all_orders";
            this.btn_all_orders.Size = new System.Drawing.Size(628, 87);
            this.btn_all_orders.TabIndex = 2;
            this.btn_all_orders.Text = "All orders";
            this.btn_all_orders.UseVisualStyleBackColor = true;
            this.btn_all_orders.Click += new System.EventHandler(this.btn_all_orders_Click);
            // 
            // btn_meal_ingredients
            // 
            this.btn_meal_ingredients.Location = new System.Drawing.Point(12, 147);
            this.btn_meal_ingredients.Name = "btn_meal_ingredients";
            this.btn_meal_ingredients.Size = new System.Drawing.Size(336, 87);
            this.btn_meal_ingredients.TabIndex = 3;
            this.btn_meal_ingredients.Text = "Meal ingredients";
            this.btn_meal_ingredients.UseVisualStyleBackColor = true;
            this.btn_meal_ingredients.Click += new System.EventHandler(this.btn_meal_ingredients_Click);
            // 
            // btn_order_meals
            // 
            this.btn_order_meals.Location = new System.Drawing.Point(369, 147);
            this.btn_order_meals.Name = "btn_order_meals";
            this.btn_order_meals.Size = new System.Drawing.Size(333, 87);
            this.btn_order_meals.TabIndex = 4;
            this.btn_order_meals.Text = "Order meals";
            this.btn_order_meals.UseVisualStyleBackColor = true;
            this.btn_order_meals.Click += new System.EventHandler(this.btn_order_meals_Click);
            // 
            // text_meal_id
            // 
            this.text_meal_id.Location = new System.Drawing.Point(12, 251);
            this.text_meal_id.Name = "text_meal_id";
            this.text_meal_id.Size = new System.Drawing.Size(336, 47);
            this.text_meal_id.TabIndex = 5;
            this.text_meal_id.Tag = "";
            // 
            // text_order_id
            // 
            this.text_order_id.Location = new System.Drawing.Point(372, 251);
            this.text_order_id.Name = "text_order_id";
            this.text_order_id.Size = new System.Drawing.Size(336, 47);
            this.text_order_id.TabIndex = 6;
            // 
            // btn_new_meal
            // 
            this.btn_new_meal.Location = new System.Drawing.Point(12, 350);
            this.btn_new_meal.Name = "btn_new_meal";
            this.btn_new_meal.Size = new System.Drawing.Size(336, 87);
            this.btn_new_meal.TabIndex = 7;
            this.btn_new_meal.Text = "New meal";
            this.btn_new_meal.UseVisualStyleBackColor = true;
            this.btn_new_meal.Click += new System.EventHandler(this.btn_new_meal_Click);
            // 
            // btn_make_order
            // 
            this.btn_make_order.Location = new System.Drawing.Point(372, 350);
            this.btn_make_order.Name = "btn_make_order";
            this.btn_make_order.Size = new System.Drawing.Size(336, 87);
            this.btn_make_order.TabIndex = 8;
            this.btn_make_order.Text = "Make order";
            this.btn_make_order.UseVisualStyleBackColor = true;
            this.btn_make_order.Click += new System.EventHandler(this.btn_make_order_Click);
            // 
            // text_new_meal
            // 
            this.text_new_meal.Location = new System.Drawing.Point(12, 508);
            this.text_new_meal.Name = "text_new_meal";
            this.text_new_meal.Size = new System.Drawing.Size(336, 579);
            this.text_new_meal.TabIndex = 9;
            this.text_new_meal.Text = "";
            // 
            // text_make_order
            // 
            this.text_make_order.Location = new System.Drawing.Point(372, 508);
            this.text_make_order.Name = "text_make_order";
            this.text_make_order.Size = new System.Drawing.Size(336, 579);
            this.text_make_order.TabIndex = 10;
            this.text_make_order.Text = "";
            // 
            // text_meal_name
            // 
            this.text_meal_name.Location = new System.Drawing.Point(12, 455);
            this.text_meal_name.Name = "text_meal_name";
            this.text_meal_name.Size = new System.Drawing.Size(336, 47);
            this.text_meal_name.TabIndex = 11;
            // 
            // text_order_title
            // 
            this.text_order_title.Location = new System.Drawing.Point(372, 455);
            this.text_order_title.Name = "text_order_title";
            this.text_order_title.Size = new System.Drawing.Size(336, 47);
            this.text_order_title.TabIndex = 12;
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 1099);
            this.Controls.Add(this.text_order_title);
            this.Controls.Add(this.text_meal_name);
            this.Controls.Add(this.text_make_order);
            this.Controls.Add(this.text_new_meal);
            this.Controls.Add(this.btn_make_order);
            this.Controls.Add(this.btn_new_meal);
            this.Controls.Add(this.text_order_id);
            this.Controls.Add(this.text_meal_id);
            this.Controls.Add(this.btn_order_meals);
            this.Controls.Add(this.btn_meal_ingredients);
            this.Controls.Add(this.btn_all_orders);
            this.Controls.Add(this.btn_show_menu);
            this.Controls.Add(this.text_result);
            this.Name = "WinForm";
            this.Text = "WinForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox text_result;
        private System.Windows.Forms.Button btn_show_menu;
        private System.Windows.Forms.Button btn_all_orders;
        private System.Windows.Forms.Button btn_meal_ingredients;
        private System.Windows.Forms.Button btn_order_meals;
        private System.Windows.Forms.TextBox text_meal_id;
        private System.Windows.Forms.TextBox text_order_id;
        private System.Windows.Forms.Button btn_new_meal;
        private System.Windows.Forms.Button btn_make_order;
        private System.Windows.Forms.RichTextBox text_new_meal;
        private System.Windows.Forms.RichTextBox text_make_order;
        private System.Windows.Forms.TextBox text_meal_name;
        private System.Windows.Forms.TextBox text_order_title;
    }
}
