using Irbags.Application.Product;
using Irbags_Api.Mappers;
using Irbags_Api.ProductController.Models.Request;
using Irbags_Api.ProductController.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.ProductController
{
    [ApiController]
    [Route("api/tag/")]
    public class TagController: ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTagsResponse>>> GetTags()
        {
            var result = await _tagService.GetTags();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetTagResponse>> GetTag(Guid id)
        {
            try
            {
                var result = await _tagService.GetTag(id);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateTagResponse>> CreateTag([FromBody] CreateTagRequest request)
        {
            var result = await _tagService.CreateTag(request.ToApplicationCreateTagRequest());

            return CreatedAtAction(
                nameof(GetTag),
                new { result.Id },
                result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UpdateTagResponse>> UpdateTag(Guid id, [FromBody] UpdateTagRequest request)
        {
            try
            {
                var result = await _tagService.UpdateTag(request.ToApplicationUpdateTagRequest(id));

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var result = await _tagService.DeleteTag(id);

            return Ok(result);
        }
    }
}
