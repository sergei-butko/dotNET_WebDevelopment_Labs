using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Repositories.Interfaces;
using Restaurant.BLL.Repositories.Repositories;
using Restaurant.BLL.Services.Interfaces;
using Restaurant.BLL.Services.Services;
using Restaurant.DAL;
using Restaurant.PL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddTransient<IIngredientService, IngredientService>();
builder.Services.AddTransient<IMealService, MealService>();
builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();