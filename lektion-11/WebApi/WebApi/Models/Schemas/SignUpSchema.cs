using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class SignUpSchema
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set;} = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public static implicit operator UserEntity(SignUpSchema schema)
        {
            return new UserEntity
            {
                FirstName = schema.FirstName,
                LastName = schema.LastName,
                PhoneNumber = schema.PhoneNumber,
                Email = schema.Email,
                UserName = schema.Email
            };
        }
    }
}
