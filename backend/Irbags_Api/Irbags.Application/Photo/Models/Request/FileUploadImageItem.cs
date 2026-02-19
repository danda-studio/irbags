namespace Irbags.Application.Photo.Models.Request
{
    public class FileUploadImageItem
    {
        public Stream Content { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}
