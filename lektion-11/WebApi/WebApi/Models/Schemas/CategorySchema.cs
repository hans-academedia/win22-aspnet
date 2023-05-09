using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class CategorySchema
    {
        [Required]
        public string CategoryName { get; set; } = null!;



        public static implicit operator CategoryEntity(CategorySchema schema) 
        {
            return new CategoryEntity
            {
                CategoryName = schema.CategoryName
            };
        }
    }
}
