using Irbags.Application.Product;
using Irbags_Api.Mappers;
using Irbags_Api.ProductController.Models.Request;
using Irbags_Api.ProductController.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.ProductController
{
    [ApiController]
    [Route("api/tag/")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTagsResponse>>> GetTags()
        {
            var result = await _productService.GetTags();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetTagResponse>> GetTag(Guid Id)
        {
            try
            {
                var result = await _productService.GetTag(Id);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<CreateTagResponse>> CreateTag([FromBody] CreateTagRequest request)
        {
            var result = await _productService.CreateTag(request.ToApplicationCreateTagRequest());

            return CreatedAtAction(
                nameof(GetTag),
                new { result.Id },
                result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UpdateTagResponse>> UpdateTag(Guid Id, [FromBody] UpdateTagRequest request)
        {
            var result = await _productService.UpdateTag(request.ToApplicationUpdateTagRequest(Id));

            return Ok(result);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTag(Guid Id)
        {
            var result = await _productService.DeleteTag(Id);

            return Ok(result);
        }
    }
}
