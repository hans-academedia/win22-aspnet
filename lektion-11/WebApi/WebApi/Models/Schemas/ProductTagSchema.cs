using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class ProductTagSchema
    {
        [Required]
        public string ArticleNumber { get; set; } = null!;
        
        [Required]
        public int TagId { get; set; }


        public static implicit operator ProductTagEntity(ProductTagSchema schema)
        {
            return new ProductTagEntity
            {
                ArticleNumber = schema.ArticleNumber,
                TagId = schema.TagId
            };
        }
    }
}
