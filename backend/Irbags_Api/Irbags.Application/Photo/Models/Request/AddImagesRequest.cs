namespace Irbags.Application.Photo.Models.Request
{
    public class AddImagesRequest
    {
        public Guid? ProductId { get; set; }
        public List<ImageItem> ImageItems { get; set; } 
    }
}