using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;

namespace Irbags.Application.Photo
{
    public interface IFileService
    {
        public Task<string> SaveFile(FileUploadImageItem imageFile, string[] alloweFileExtensions);
        Task<List<SaveFilesResponse>> SaveFiles(List<FileUploadImageItem> files, string[] allowedExtensions);
        public void DeleteFile(string fileNameWithExtension);
    }
}
