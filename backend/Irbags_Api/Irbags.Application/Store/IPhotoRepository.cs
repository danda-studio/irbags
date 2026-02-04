using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Core.Product;

namespace Irbags.Application.Store
{
    public interface IPhotoRepository
    {
        Task<IReadOnlyCollection<GetImageResponse>> GetImagesByProductId(Guid Id);
        Task<IReadOnlyCollection<GetImageResponse>> GetImages();
        Task<GetImageResponse?> GetImage(string key);
        Task<AddImageResponse> AddImage(Guid? productId, string key, string extension);
        //Task<AddImagesResponse> AddImages(Guid? productId, string key, string extension);
        Task AddImagesBatch(List<ProductImage> images, Guid? productId);
        Task<UpdateImageResponse?> UpdateImage(string key);
        Task<bool> DeleteImage(string key);
    }
}
