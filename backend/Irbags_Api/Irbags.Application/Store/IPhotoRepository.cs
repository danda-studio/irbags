using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;

namespace Irbags.Application.Store
{
    public interface IPhotoRepository
    {
        Task<IReadOnlyCollection<GetImageResponse>> GetImages();
        Task<GetImageResponse?> GetImage(string key);
        Task<AddImageResponse> AddImage(AddImageRequest request);
        Task<UpdateImageResponse?> UpdateImage(UpdateImageRequest request);
        Task<bool> DeleteImage(string key);
    }
}
