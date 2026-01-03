using Microsoft.AspNetCore.Http;

namespace Irbags.Application.Photo
{
    public interface IFileService
    {
        public Task<string> SaveFile(IFormFile imageFile, string[] alloweFileExtensions, string name);
        public void DeleteFile(string fileNameWithExtension);
    }
}
