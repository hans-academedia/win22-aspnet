using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repos;

public class ProductRepo : Repo<ProductEntity>
{
    public ProductRepo(DataContext context) : base(context)
    {
    }
}
