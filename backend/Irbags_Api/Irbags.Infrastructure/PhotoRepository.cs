using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Infrastructure
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<GetImagesResponse>> GetImages()
        {
            return null;
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            return null;
        }

        public async Task<UpdateImageResponse> UpdateImage(UpdateImageRequest request)
        {
            return null;
        }

        public async Task<bool> DeleteImage(Guid Id)
        {
            return false;
        }
    }
}
