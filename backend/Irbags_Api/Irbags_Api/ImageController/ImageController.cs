using Irbags.Application.Photo;
using Irbags_Api.ImageController.Models.Request;
using Irbags_Api.ImageController.Models.Response;
using Irbags_Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.ImageController
{
    [ApiController]
    [Route("api/image/")]
    public class ImageController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        public ImageController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetImageResponse>>> GetImages()
        {
            var result = await _photoService.GetImages();

            return Ok(result);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<GetImageResponse>> GetImage(string key)
        {
            try
            {
                var result = await _photoService.GetImage(key);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AddImageResponse>> AddImage([FromForm] AddImageRequest request)
        {
            var result = await _photoService.AddImage(request.ToApplicationAddImageRequest());

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{key}")]
        public async Task<ActionResult<UpdateImageResponse>> UpdateImage(string key, [FromBody] UpdateImageRequest request)
        {
            try
            {
                var result = await _photoService.UpdateImage(request.ToApplicationUpdateImageRequest(key));

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteImage(string key)
        {
            var result = await _photoService.DeleteImage(key);

            return Ok(result);
        }
    }
}
