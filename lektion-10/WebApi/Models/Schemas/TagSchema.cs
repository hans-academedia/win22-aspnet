using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class TagSchema
    {
        [Required]
        [MinLength(2)]
        public string TagName { get; set; } = null!;




        public static implicit operator TagEntity(TagSchema schema) 
        {
            if (schema != null)
            {
                return new TagEntity
                {
                    TagName = schema.TagName
                };
            }

            return null!;
        }
    }
}
