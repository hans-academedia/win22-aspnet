using _02_AspNet_WebApi.Models.Dtos;
using _02_AspNet_WebApi.Models.Entities;
using _02_AspNet_WebApi.Models.Schemas;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _02_AspNet_WebApi.Helpers.Services;

public class UserService
{
    private readonly UserManager<IdentityUserEntity> _userManager;

    public UserService(UserManager<IdentityUserEntity> userManager)
    {
        _userManager = userManager;
    }


    public async Task<bool> UserExistsAsync(Expression<Func<IdentityUserEntity, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var items = await _userManager.Users.ToListAsync();

        var users = new List<User>();
        foreach (var item in items)
            users.Add(item);
        
        return users;
    }


    public async Task<User> GetAsync(Expression<Func<IdentityUserEntity, bool>> expression)
    {
        var result = await _userManager.Users.FirstOrDefaultAsync(expression);
        if (result != null)
            return result;

        return null!;
    }


    public async Task<bool> RegisterAsync(UserRegisterSchema userRegisterSchema)
    {
        var result = await _userManager.CreateAsync(userRegisterSchema, userRegisterSchema.Password);
        return result.Succeeded;
    }
}
