
using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;

namespace Irbags.Application.Store
{
    public interface IPhotoRepository
    {
        Task<IReadOnlyCollection<GetImagesResponse>> GetImages();
        Task<AddImageResponse> AddImage(AddImageRequest request);
        Task<UpdateImageResponse?> UpdateImage(UpdateImageRequest request);
        Task<bool> DeleteImage(Guid Id);
    }
}
