using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {
        public ProductTagRepo(DataContext context) : base(context)
        {
        }
    }
}
