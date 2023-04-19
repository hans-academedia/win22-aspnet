using SharedLibrary.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.Dtos;

public class UserLoginModel
{
    [Display(Name = "E-mail Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Keep me logged in")]
    public bool RememberMe { get; set; }

    public static implicit operator AppUser(UserLoginModel model)
    {
        return new AppUser
        {
            UserName = model.Email,
            Email = model.Email
        };
    }
}
