using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Repos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

// Repositories
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<ProductRepo>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();

// Routes
app.MapGet("/api/categories", async (context) =>
{
    var categoryRepo = context.RequestServices.GetService<CategoryRepo>();
    await context.Response.WriteAsJsonAsync(await categoryRepo!.GetAllAsync());
}).WithName("Categories")
.WithOpenApi();

app.MapGet("/api/products", async (context) =>
{
    var productRepo = context.RequestServices.GetService<ProductRepo>();
    await context.Response.WriteAsJsonAsync(await productRepo!.GetAllAsync());
}).WithName("Products")
.WithOpenApi();


app.Run();