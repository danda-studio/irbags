using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<string> SaveFile(FileUploadImageItem file, string[] allowedExtensions)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            
            var baseUrl = _settings.BaseUrl.TrimEnd('/');
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file extension");

            var filePath = Path.Combine(_settings.UploadPath, file.FileName);

            await using var output = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);

            await file.Content.CopyToAsync(output);

            return $"{baseUrl}uploads/{file.FileName}";

        }

        public async Task<List<SaveFilesResponse>> SaveFiles(List<FileUploadImageItem> files, string[] allowedExtensions)
        {
            if (files.Count() == 0)
                throw new ArgumentException("The number of files cannot be 0");

            var baseUrl = _settings.BaseUrl.TrimEnd('/');
            var fileName = new List<SaveFilesResponse>();

            foreach(var file in files)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                    throw new ArgumentException("Invalid file extension");

                var filePath = Path.Combine(_settings.UploadPath, file.FileName);

                await using var output = new FileStream(
                    filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);

                await file.Content.CopyToAsync(output);

                fileName.Add(new SaveFilesResponse
                {
                    Key = file.FileName,
                    ImageUrl = $"{baseUrl}uploads/{file.FileName}"
                });

            }

            return fileName;
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
