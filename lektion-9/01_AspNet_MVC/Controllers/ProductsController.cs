using _01_AspNet_MVC.Helpers.Services;
using _01_AspNet_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _01_AspNet_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;

        public ProductsController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                await _productManager.AddAsync(viewModel.Form);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
