using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";

        return View();
    }
}
