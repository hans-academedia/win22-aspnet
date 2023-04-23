using _02_AspNet_WebApi.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace _02_AspNet_WebApi.Models.Schemas
{
    public class UserRegisterSchema
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
        public string Password { get; set; } = null!;

        public static implicit operator IdentityUserEntity(UserRegisterSchema schema)
        {
            return new IdentityUserEntity
            {
                FirstName = schema.FirstName,
                LastName = schema.LastName,
                PhoneNumber = schema.PhoneNumber,
                Email = schema.Email,
                UserName = schema.Email,
            };
        }
    }
}
