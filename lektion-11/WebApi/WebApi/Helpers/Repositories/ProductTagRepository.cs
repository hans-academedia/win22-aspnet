using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ProductTagRepository : Repo<ProductTagEntity>
    {
        public ProductTagRepository(DataContext context) : base(context)
        {
        }
    }
}
