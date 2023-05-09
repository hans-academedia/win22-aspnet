using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpSchema schema)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(schema, schema.Password);
                if (result.Succeeded)
                    return Created("", null!);
            }

            return BadRequest();
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInSchema schema)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(schema.Email, schema.Password, schema.RememberMe, false);
                if (result.Succeeded)
                {
                    var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == schema.Email);
                    if (userEntity != null)
                    {

                        var token = TokenGenerator.Generate(await _userManager.GetClaimsAsync(userEntity), DateTime.Now.AddHours(1));
                        return Ok(token);
                    }

                    return Problem();
                }
                    
            }

            return BadRequest();
        }

    }
}
