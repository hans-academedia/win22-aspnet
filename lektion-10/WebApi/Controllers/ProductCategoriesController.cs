using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/products/categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoriesController(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCategorySchema schema)
        {
            if (ModelState.IsValid)
            {
                var category = await _productCategoryService.GetProductCategoryAsync(schema);
                if (category != null)
                    return Conflict(new { category, error = "A category with the same name already exists." });

                category = await _productCategoryService.CreateProductCategoryAsync(schema);
                if (category != null)
                    return Created("", category);
            }
            return BadRequest(schema);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                var _category = await _productCategoryService.GetProductCategoryAsync(categoryName);
                if (_category != null)
                    return Ok(_category);
            }
            else
            {
                var categories = await _productCategoryService.GetProductCategoriesAsync();
                if (categories != null)
                    return Ok(categories);
            }

            return NotFound();
        }
    }
}
