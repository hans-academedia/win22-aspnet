using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Identity;

namespace SharedLibrary.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AddressId))]
public class UserAddressEntity
{
    public string UserId { get; set; } = null!;
    public string AddressId { get; set; } = null!;

    public AppUser User { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;
}