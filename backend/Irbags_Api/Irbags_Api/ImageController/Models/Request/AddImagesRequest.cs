namespace Irbags_Api.ImageController.Models.Request
{
    public class AddImagesRequest
    {
        public Guid? ProductId { get; set; }

        public List<ImageItem> ImageItems { get; set; }
    }
}
