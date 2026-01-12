using Irbags.Application.Photo.Models.Request;
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

        public async Task<string> SaveFile(FileUploadImageItem file, string[] allowedExtensions, string fileNameWithExtension)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file extension");

            var filePath = Path.Combine(_settings.UploadPath, fileNameWithExtension);

            await using var output = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);

            await file.Content.CopyToAsync(output);

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
