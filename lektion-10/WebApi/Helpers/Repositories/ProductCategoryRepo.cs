using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
