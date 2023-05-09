using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

        public static implicit operator Category(CategoryEntity entity)
        {
            if (entity != null)
            {
                return new Category
                {
                    Id = entity.Id,
                    CategoryName = entity.CategoryName,
                };
            }

            return null!;
        }
    }
}
