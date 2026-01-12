using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Application.Store;
using Irbags.Core.Product;

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
            
            if(image == null)
            {
                throw new KeyNotFoundException($"Image with key '{key}' not found");
            }

            return new GetImageResponse
            {
                Id = image.Id,
                Name = image.Name,
                RelativeUrl = image.RelativeUrl
            };
        }

        public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"Only the following formats are allowed: {string.Join(", ", _allowedExtensions)}");
            }

            var savedFileName = await _fileService.SaveFile(request.Image, _allowedExtensions, $"{request.Key}{extension}");

            var image = await _photoRepository.UpdateImage(new UpdateImageRequest
            {
                Image = request.Image,
                Key = request.Key
            });

            if(image == null)
            {
                throw new KeyNotFoundException($"Image not found");
            }

            return new UpdateImageResponse
            {
                Id = image.Id,
                Name = image.Name,
                RelativeUrl = image.RelativeUrl
            };
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Image == null)
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
