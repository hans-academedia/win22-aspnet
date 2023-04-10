using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<CustomIdentityUser> _userManager;

    public RegisterController(UserManager<CustomIdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _userManager.FindByNameAsync(viewModel.Email) == null)
            {
                var result = await _userManager.CreateAsync(viewModel, viewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
            }
                
            ModelState.AddModelError("", "A user with the same e-mail address already exists");
        }

        return View(viewModel);
    }
}
