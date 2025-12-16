using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;

namespace Irbags.Application.Photo
{
    public interface IPhotoService
    {
        public Task<IReadOnlyCollection<GetImagesResponse>> GetImages();
        public Task<AddImageResponse> AddImage(AddImageRequest request);
        public Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request);
        public Task<bool> DeleteImage(Guid id);

    }
}
