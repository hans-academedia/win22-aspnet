using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Identity;
using SharedLibrary.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    public AuthenticationController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterModel model)
    {
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(await _userManager.GetEmailAsync(model)))
                return Conflict(ModelState);
            
            return Created("", null);  
        } 

        return BadRequest(model);    
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _userManager.CheckPasswordAsync(model, model.Password))
                return Ok(TokenGenerator.Generate(await _userManager.GetClaimsAsync(model), DateTime.Now.AddHours(1)));

            ModelState.AddModelError("", "Incorrect email or password");
        }

        return Unauthorized(model);
    }
}
