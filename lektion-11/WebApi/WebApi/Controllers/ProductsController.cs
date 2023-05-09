using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateAsync(schema);
                if (product != null)
                    return Created("", product);
            }

            return BadRequest();
        }

        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> Get(string articleNumber)
        {
            var product = await _productService.GetAsync(articleNumber);
            if (product != null)
                return Ok(product);

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
    }
}
