using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApp.Models.Dtos;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ProductsViewModel();
            return View(viewModel);
        }



        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductRegistrationViewModel();
            
            using var httpClient = new HttpClient();
            var categories = await httpClient.GetFromJsonAsync<IEnumerable<ProductCategory>>("https://localhost:7275/api/products/categories")!;
            if (categories != null)
                foreach(var category in categories) 
                    viewModel.ProductCategoryOptions.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.CategoryName });

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRegistrationViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(viewModel.TagList))
                    viewModel.Tags = viewModel.TagList.Split(";").ToList();

                using var httpClient = new HttpClient();

                using var content = new MultipartFormDataContent
                {
                    { new StringContent(viewModel.ArticleNumber), "ArticleNumber" },
                    { new StringContent(viewModel.ProductName), "ProductName" },
                    { new StringContent(viewModel.ProductDescription!), "ProductDescription" },
                    { new StringContent(viewModel.ProductPrice.ToString()), "ProductPrice" },
                    { new StringContent(viewModel.ProductCategoryId.ToString()), "ProductCategoryId" },
                };

                foreach (var tag in viewModel.Tags)
                {
                    var stringContent = new StringContent(tag);
                    content.Add(stringContent, "Tags");
                }

                if (viewModel.ProductImageUpload != null)
                {
                    var fileContent = new ByteArrayContent(await viewModel.ProductImageUpload.ReadAllBytesAsync());
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(viewModel.ProductImageUpload.ContentType);
                    content.Add(fileContent, "ProductImageUpload", viewModel.ProductImageUpload.FileName);
                }


                var result = await httpClient.PostAsync("https://localhost:7275/api/products", viewModel)!;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Products");
            }

            return View(viewModel);
        }
    }
}
