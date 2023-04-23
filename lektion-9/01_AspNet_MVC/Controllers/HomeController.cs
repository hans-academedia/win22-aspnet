using Microsoft.AspNetCore.Mvc;

namespace _01_AspNet_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
