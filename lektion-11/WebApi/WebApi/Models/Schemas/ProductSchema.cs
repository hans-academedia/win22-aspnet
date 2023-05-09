using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class ProductSchema
    {
        [Required]
        public string ArticleNumber { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
        
        public IFormFile? Image { get; set; }




        public static implicit operator ProductEntity(ProductSchema schema)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = schema.ArticleNumber,
                Name = schema.Name,
                CategoryId = schema.CategoryId,
                Price = schema.Price,
                Description = schema.Description,
            };

            if (schema.Image != null)
                entity.ImageUrl = $"{entity.ArticleNumber}_{schema.Image.FileName}";

            return entity;
        }
    }
}
