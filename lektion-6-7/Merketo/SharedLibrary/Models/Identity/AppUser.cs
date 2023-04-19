using Microsoft.AspNetCore.Identity;
using SharedLibrary.Models.Entities;

namespace SharedLibrary.Models.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CompanyName { get; set; } = null!;

    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
}
