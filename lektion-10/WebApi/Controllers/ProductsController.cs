using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductAsync(schema.ArticleNumber);
                if (product != null)
                    return Conflict(new { product, error = "A product with the same article number already exists." });

                product = await _productService.CreateProductAsync(schema);
                if (product != null)
                    return Created("", product);
            }
            return BadRequest(schema);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? articleNumber)
        {
            if (!string.IsNullOrEmpty(articleNumber))
            {
                var product = await _productService.GetProductAsync(articleNumber);
                if (product != null)
                    return Ok(product);
            }
            else
            {
                var products = await _productService.GetProductsAsync();
                if (products != null)
                    return Ok(products);
            }

            return NotFound();
        }
    }
}
