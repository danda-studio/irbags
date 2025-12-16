using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application.Photo
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<IReadOnlyCollection<GetImagesResponse>> GetImages()
        {
            return null;
        }

        public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
        {
            return new UpdateImageResponse();
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            return new AddImageResponse();
        }

        public async Task<bool> DeleteImage(Guid Id)
        {
            return true;
        }
    }
}
