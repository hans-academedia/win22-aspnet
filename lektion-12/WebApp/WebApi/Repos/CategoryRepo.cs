using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repos;

public class CategoryRepo : Repo<CategoryEntity>
{
    public CategoryRepo(DataContext context) : base(context)
    {
    }
}
