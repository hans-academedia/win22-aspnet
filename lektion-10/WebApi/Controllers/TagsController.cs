using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(TagSchema schema)
        {
            if (ModelState.IsValid)
            {
                var tag = await _tagService.GetTagAsync(schema);
                if (tag != null)
                    return Conflict(new { tag, error = "A tag with the same tag name already exists." });

                tag = await _tagService.CreateTagAsync(schema);
                if (tag != null)
                    return Created("", tag);
            }
            return BadRequest(schema);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? tagName)
        {
            if (!string.IsNullOrEmpty(tagName))
            {
                var _tag = await _tagService.GetTagAsync(tagName);
                if (_tag != null)
                    return Ok(_tag);
            } 
            else
            {
                var tags = await _tagService.GetTagsAsync();
                if (tags != null)
                    return Ok(tags);
            }

            return NotFound();
        }

    }
}
