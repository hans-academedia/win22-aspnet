using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
            {
                return new Product
                {
                    ArticleNumber = entity.ArticleNumber,
                    Name = entity.Name,
                    Description = entity.Description,
                    ImageUrl = entity.ImageUrl,
                    Price = entity.Price,
                    Category = entity.Category,
                };
            }

            return null!;
        }
    }
}
