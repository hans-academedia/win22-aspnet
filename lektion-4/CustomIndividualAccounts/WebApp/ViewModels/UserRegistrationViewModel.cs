using System.ComponentModel.DataAnnotations;
using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UserRegistrationViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "E-mail is required.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirming password is required.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Street Name")]
    public string? StreetName { get; set; }

    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }



    public static implicit operator CustomIdentityUser(UserRegistrationViewModel viewModel)
    {
        return new CustomIdentityUser
        {
            UserName = viewModel.Email,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber
        };
    }
}
