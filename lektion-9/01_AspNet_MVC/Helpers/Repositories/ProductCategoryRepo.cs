using _01_AspNet_MVC.Helpers.Contexts;
using _01_AspNet_MVC.Models.Entities;

namespace _01_AspNet_MVC.Helpers.Repositories
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
