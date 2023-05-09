using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class TagRepo : Repo<TagEntity>
    {
        public TagRepo(DataContext context) : base(context)
        {
        }
    }
}
