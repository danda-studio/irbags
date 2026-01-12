using Irbags.Application.Photo;
using Irbags_Api.ImageController.Models.Request;
using Irbags_Api.ImageController.Models.Response;
using Irbags_Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Irbags_Api.ImageController
{
    [ApiController]
    [Route("api/image/")]
    public class ImageController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly PhotoSettings _settings;
        public ImageController(IPhotoService photoService, IOptions<PhotoSettings> settings)
        {
            _photoService = photoService;
            _settings = settings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetImageResponse>>> GetImages()
        {
            var result = await _photoService.GetImages();

            var baseUrl = _settings.BaseUrl.TrimEnd('/');

            var response = result.Select(image => new GetImageResponse
            {
                Name = image.Name,
                ImageUrl = $"{baseUrl}{image.RelativeUrl}"
            });

            return Ok(response);
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<GetImageResponse>> GetImage(string key)
        {
            try
            {
                var result = await _photoService.GetImage(key);

                var baseUrl = _settings.BaseUrl.TrimEnd('/');

                return Ok(new GetImageResponse
                {
                    Name = result.Name,
                    ImageUrl = $"{baseUrl}{result.RelativeUrl}"
                });
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

            var baseUrl = _settings.BaseUrl.TrimEnd('/');

            return Ok(new AddImageResponse 
            {
                Name = result.Name,
                ImageUrl = $"{baseUrl}{result.RelativeUrl}"
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{key}")]
        public async Task<ActionResult<UpdateImageResponse>> UpdateImage(string key, [FromBody] UpdateImageRequest request)
        {
            try
            {
                var result = await _photoService.UpdateImage(request.ToApplicationUpdateImageRequest(key));

                var baseUrl = _settings.BaseUrl.TrimEnd('/');

                return Ok(new UpdateImageResponse
                {
                    Name = result.Name,
                    ImageUrl = $"{baseUrl}{result.RelativeUrl}" 
                });
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
