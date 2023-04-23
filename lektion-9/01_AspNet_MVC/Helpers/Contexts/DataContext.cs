using _01_AspNet_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_AspNet_MVC.Helpers.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
