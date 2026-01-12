namespace Irbags.Application.Photo.Models.Request
{
    public class AddImageRequest
    {
        public Guid? ProductId { get; set; }
        public string Key { get; set; }
        public FileUploadImageItem Image { get; set; }
    }
}