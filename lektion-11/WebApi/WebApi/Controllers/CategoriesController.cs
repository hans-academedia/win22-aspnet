using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategorySchema schema)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetOrCreateAsync(schema);
                if (category != null)
                    return Ok(category);
            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();        
            return Ok(categories);
        }
    }
}
