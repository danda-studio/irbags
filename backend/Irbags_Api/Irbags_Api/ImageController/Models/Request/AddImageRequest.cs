namespace Irbags_Api.ImageController.Models.Request
{
    public class AddImageRequest
    {

        public Guid? ProductId { get; set; }
        public string Key { get; set; }
        public IFormFile Image { get; set; }

    }
}
