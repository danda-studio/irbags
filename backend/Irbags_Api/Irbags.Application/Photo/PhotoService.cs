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

        public async Task<IReadOnlyCollection<GetImageResponse>> GetImagesByProductId(Guid Id)
        {
            var images = await _photoRepository.GetImagesByProductId(Id);
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

            var savedFileUrl = await _fileService.SaveFile(request.Image, _allowedExtensions);

            var image = await _photoRepository.UpdateImage(request.Key);

            if(image == null)
            {
                throw new KeyNotFoundException($"Image not found");
            }

            return new UpdateImageResponse
            {
                ProductId = image.ProductId,
                Name = image.Name,
                RelativeUrl = savedFileUrl,
            };
        }

        public async Task<AddImagesResponse> AddImages(AddImagesRequest request)
        {
            if (request.ImageItems == null || request.ImageItems.Count == 0)
                throw new ArgumentException("At least one image is required.");

            if (request.ImageItems.Count > 6)
                throw new ArgumentException("You can upload no more than 6 images.");

            foreach (var item in request.ImageItems)
            {
                var extension = Path.GetExtension(item.Image.FileName).ToLowerInvariant();
                if (!_allowedExtensions.Contains(extension))
                    throw new ArgumentException($"Invalid format: {extension}");
            }

            var savedFiles = await _fileService.SaveFiles(
                request.ImageItems.Select(x => x.Image).ToList(),
                _allowedExtensions);

            var images = savedFiles.Select(file => new ProductImage
            {
                Id = Guid.NewGuid(),
                Name = file.FileName,
                Extension = Path.GetExtension(file.FileName)
            }).ToList();

            await _photoRepository.AddImagesBatch(images, request.ProductId);

            return new AddImagesResponse
            {
                Images = images.Select(img => new ImageResultItem
                {
                    Name = img.Name,
                    RelativeUrl = $"/uploads/{img.Name}{img.Extension}"
                }).ToList()
            };
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (request.Image == null)
                throw new ArgumentException("Image file is required.");

            var extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"Only the following formats are allowed: {string.Join(", ", _allowedExtensions)}");
            }

            var savedFileName = await _fileService.SaveFile(request.Image, _allowedExtensions);

            var image = await _photoRepository.AddImage(request.ProductId, request.Image.FileName, extension);

            return new AddImageResponse
            {
                Id = image.Id,
                Name = image.Name,
                RelativeUrl = savedFileName,
            };
        }

        public async Task<bool> DeleteImage(string key)
        {
            var result = await _photoRepository.DeleteImage(key);
            return result;
        }

    }
}
