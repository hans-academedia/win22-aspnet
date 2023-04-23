using _01_AspNet_MVC.Helpers.Contexts;
using _01_AspNet_MVC.Models.Entities;

namespace _01_AspNet_MVC.Helpers.Repositories
{
    public class ProductRepo : Repo<ProductEntity>
    {
        public ProductRepo(DataContext context) : base(context)
        {
        }
    }
}
