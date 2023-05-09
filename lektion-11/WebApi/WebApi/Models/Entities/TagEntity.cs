using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

        public static implicit operator Tag(TagEntity entity)
        {
            if (entity != null)
            {
                return new Tag
                {
                    Id = entity.Id,
                    TagName = entity.TagName,
                };
            }

            return null!;
        }
    }
}
