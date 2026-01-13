namespace Irbags_Api.ImageController.Models.Request
{
    public class ImageItem
    {
        public string Key { get; set; }
        public IFormFile Image { get; set; }
    }
}
