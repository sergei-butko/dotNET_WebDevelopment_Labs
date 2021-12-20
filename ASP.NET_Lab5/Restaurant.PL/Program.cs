using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ASP.NET_Lab5", 
        Version = "v1"
    });
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddTransient<IMealService, MealService>();
builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c
        .SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET_Lab5 v1")
    );
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();