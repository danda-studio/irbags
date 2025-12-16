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
        public async Task<ActionResult<IEnumerable<GetImagesResponse>>> GetImages()
        {
            var result = await _photoService.GetImages();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AddImageResponse>> AddImage([FromBody] AddImageRequest request)
        {
            var result = await _photoService.AddImage(request.ToApplicationAddImageRequest());

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UpdateImageResponse>> UpdateImage(Guid id, [FromBody] UpdateImageRequest request)
        {
            var result = await _photoService.UpdateImage(request.ToApplicationUpdateImageRequest(id));

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var result = await _photoService.DeleteImage(id);

            return Ok(result);
        }


    }
}
