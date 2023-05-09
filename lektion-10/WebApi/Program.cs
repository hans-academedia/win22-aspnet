using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("database")));

// Repos
builder.Services.AddScoped<ProductCategoryRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductTagRepo>();

// Services/Managers
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


/*  
    CORS - Cross Origin Resource Sharing (Access Management)
    ------------------------------------------------------------------------------------------------------
    AllowAnyOrigin()        =>      alla adresser får komma åt apiet, oavsett domän eller portnummer
    AllowAnyMethod()        =>      tillåter alla HTTP Methods (POST, PUT, PATCH, GET, DELETE...)
    AllowAnyHeader()        =>      tillåter alla typer av headers (Content-Type, Accept, Authorization, X-Header-Key)
 
*/