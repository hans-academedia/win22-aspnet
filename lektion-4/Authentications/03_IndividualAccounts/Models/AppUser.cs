using Microsoft.AspNetCore.Identity;

namespace _03_IndividualAccounts.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
