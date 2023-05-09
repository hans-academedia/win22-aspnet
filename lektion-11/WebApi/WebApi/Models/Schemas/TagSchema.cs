using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class TagSchema
    {
        [Required]
        public string TagName { get; set; } = null!;



        public static implicit operator TagEntity(TagSchema schema)
        {
            return new TagEntity
            {
                TagName = schema.TagName
            };
        }
    }
}
