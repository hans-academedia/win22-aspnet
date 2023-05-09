using Microsoft.AspNetCore.Identity;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public static implicit operator User(UserEntity entity)
        {
            if (entity != null)
            {
                return new User
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber
                };
            }

            return null!;
        }

    }
}
