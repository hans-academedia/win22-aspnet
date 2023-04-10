using Microsoft.AspNetCore.Identity;

namespace WebApp.Models.Identity
{
    // AppUser, ApplicationUser, User
    public class CustomIdentityUser : IdentityUser
    {

        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;
        
        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;

    }
}
