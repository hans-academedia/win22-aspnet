using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class TagRepository : Repo<TagEntity>
    {
        public TagRepository(DataContext context) : base(context)
        {
        }
    }
}
