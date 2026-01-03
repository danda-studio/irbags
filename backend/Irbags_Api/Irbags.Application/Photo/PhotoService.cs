using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Application.Store;
using Microsoft.AspNetCore.Http;

namespace Irbags.Application.Photo
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IFileService _fileService;

        private readonly string[] _allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        public PhotoService(IPhotoRepository photoRepository, IFileService fileService)
        {
            _photoRepository = photoRepository;
            _fileService = fileService;
        }

        public async Task<IReadOnlyCollection<GetImageResponse>> GetImages()
        {
            var images = await _photoRepository.GetImages();
            return images;
        }

        public async Task<GetImageResponse> GetImage(string key)
        {
            var image = await _photoRepository.GetImage(key);
            return image ?? throw new KeyNotFoundException($"Image with key '{key}' not found");
        }

        public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Image == null || request.Image.Length == 0)
                throw new ArgumentException("Image file is required.");

            var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"Only the following formats are allowed: {string.Join(", ", _allowedExtensions)}");
            }

            var savedFileName = await _fileService.SaveFile(request.Image, _allowedExtensions, $"{request.Key}{extension}");

            var response = await _photoRepository.UpdateImage(new UpdateImageRequest
            {
                Image = request.Image,
                Key = request.Key
            });

            return response ?? throw new KeyNotFoundException($"Image not found");
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Image == null || request.Image.Length == 0)
                throw new ArgumentException("Image file is required.");

            var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"Only the following formats are allowed: {string.Join(", ", _allowedExtensions)}");
            }

            var savedFileName = await _fileService.SaveFile(request.Image, _allowedExtensions, $"{request.Key}{extension}");

            var response = await _photoRepository.AddImage(new AddImageRequest
            {
                ProductId = request.ProductId,
                Image = request.Image,
                Key = request.Key
            });

            return response;
        }

        public async Task<bool> DeleteImage(string key)
        {
            var result = await _photoRepository.DeleteImage(key);
            return result;
        }

    }
}
