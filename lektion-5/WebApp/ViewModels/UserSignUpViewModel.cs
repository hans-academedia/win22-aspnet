using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class UserSignUpViewModel
{
    public string FirstName { get; set; } = null!;
    

    public string LastName { get; set; } = null!;

    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    

    public string? PhoneNumber { get; set; }

    
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
    
    
    public string? StreetName { get; set; }
    
    
    public string? PostalCode { get; set; }
    
    
    public string? City { get; set; }


    public static implicit operator IdentityUser(UserSignUpViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

    public static implicit operator UserProfileEntity(UserSignUpViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City
        };
    }
}
