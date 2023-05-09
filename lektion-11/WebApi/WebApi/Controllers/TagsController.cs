using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(TagSchema schema)
        {
            if (ModelState.IsValid)
            {
                var tag = await _tagService.GetOrCreateAsync(schema);
                if (tag != null)
                    return Ok(tag);
            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAllAsync();
            return Ok(tags);
        }
    }
}
