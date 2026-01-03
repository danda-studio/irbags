using Microsoft.AspNetCore.Http;

namespace Irbags.Application.Photo.Models.Request
{
    public class UpdateImageRequest
    {
        public string Key { get; set; }
        public IFormFile Image { get; set; }
    }
}
