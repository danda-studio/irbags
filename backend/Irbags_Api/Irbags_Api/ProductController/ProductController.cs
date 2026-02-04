using Irbags.Application.Product;
using Irbags_Api.Mappers;
using Irbags_Api.ProductController.Models.Request;
using Irbags_Api.ProductController.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.ProductController
{
    [ApiController]
    [Route("api/product/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductsResponse>>> GetProducts()
        {
            var result = await _productService.GetProducts();

            return Ok(result);
        }

        //[HttpGet("{id:guid}")]
        //public async Task<ActionResult<GetProductResponse>> GetProduct(Guid id)
        //{
        //    try
        //    {
        //        var result = await _productService.GetProduct(id);
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> CreateProduct([FromForm] CreateProductRequest request)
        {
            var result = await _productService.CreateProduct(request.ToApplicationCreateProductRequest());

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                var result = await _productService.UpdateProduct(request.ToApplicationUpdateProductRequest(id));

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProduct(id);

            return Ok(result);
        }

    }
}
