using _01_AspNet_MVC.Helpers.Contexts;
using _01_AspNet_MVC.Helpers.Repositories;
using _01_AspNet_MVC.Helpers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<ProductCategoryManager>();
builder.Services.AddScoped<ProductManager>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ProductCategoryRepo>();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
