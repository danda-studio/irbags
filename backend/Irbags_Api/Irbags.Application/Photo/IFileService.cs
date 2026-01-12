using Irbags.Application.Photo.Models.Request;

namespace Irbags.Application.Photo
{
    public interface IFileService
    {
        public Task<string> SaveFile(FileUploadImageItem imageFile, string[] alloweFileExtensions, string name);
        public void DeleteFile(string fileNameWithExtension);
    }
}
