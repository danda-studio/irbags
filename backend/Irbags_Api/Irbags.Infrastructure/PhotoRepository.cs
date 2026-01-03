using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;
using Irbags.Core.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Irbags.Infrastructure
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<GetImageResponse>> GetImages()
        {
            var images = await _dbContext.ProductImages
                .AsNoTracking()
                .Select(t => new GetImageResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            return new ReadOnlyCollection<GetImageResponse>(images);
        }

        public async Task<GetImageResponse?> GetImage(string key)
        {
            var image = await _dbContext.ProductImages
                .Where(t => t.Name == key)
                .Select(t => new GetImageResponse
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .FirstOrDefaultAsync();

            return image;
        }

        public async Task<AddImageResponse> AddImage(AddImageRequest request)
        {
            var imageEntity = new ProductImage
            {
                Id = Guid.NewGuid(),
                Name = request.Key 
            };


            if (request.ProductId != null)
            {
                var product = await _dbContext.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == request.ProductId);

                if (product != null)
                {
                    product.Images ??= new List<ProductImage>();
                    product.Images.Add(imageEntity);
                    imageEntity.Product = product;
                } 
            }

            _dbContext.ProductImages.Add(imageEntity);
            await _dbContext.SaveChangesAsync();

            return new AddImageResponse
            {
                Id = imageEntity.Id,
                FileName = imageEntity.Name,
                Url = $"/Uploads/{imageEntity.Name}" 
            };
        }

        public async Task<UpdateImageResponse?> UpdateImage(UpdateImageRequest request)
        {
            var image = await _dbContext.ProductImages
                .FirstOrDefaultAsync(t => t.Name == request.Key);

            if (image == null)
                return null;

            image.Name = request.Key;
            await _dbContext.SaveChangesAsync();

            return new UpdateImageResponse
            {
                Id = image.Id,
                Key = image.Name
            };
        }

        public async Task<bool> DeleteImage(string key)
        {
            var image = _dbContext.ProductImages
                 .FirstOrDefault(t => t.Name == key);

            if (image == null)
                return false;

            _dbContext.ProductImages.Remove(image);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
