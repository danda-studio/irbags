using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;

namespace Irbags.Application.Photo
{
    public class FileService : IFileService
    {
        private readonly PhotoSettings _settings;

        public FileService(IOptions<PhotoSettings> settings)
        {
            _settings = settings.Value;

            if (!Directory.Exists(_settings.UploadPath))
            {
                Directory.CreateDirectory(_settings.UploadPath);
            }
        }

        public async Task<string> SaveFile(IFormFile imageFile, string[] allowedFileExtensions, string fileNameWithExtension)
        {
            if (imageFile == null) throw new ArgumentNullException(nameof(imageFile));
            if (string.IsNullOrWhiteSpace(fileNameWithExtension)) throw new ArgumentException("File name cannot be empty.");

            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!allowedFileExtensions.Contains(extension))
                throw new ArgumentException($"Only {string.Join(", ", allowedFileExtensions)} files are allowed.");

            var filePath = _settings.UploadPath.TrimEnd('/') + "/" + fileNameWithExtension;

            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            return fileNameWithExtension;
        }

        public void DeleteFile(string fileNameWithExtension)
        {
            if (string.IsNullOrEmpty(fileNameWithExtension))
                throw new ArgumentNullException(nameof(fileNameWithExtension));

            var filePath = _settings.UploadPath.TrimEnd('/') + "/" + fileNameWithExtension;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
