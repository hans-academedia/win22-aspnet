using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for products";
            return View();
        }
    }
}
