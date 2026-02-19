using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
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
                    RelativeUrl = $"/uploads/{t.Name}{t.Extension}"
                }).ToListAsync();

            return new ReadOnlyCollection<GetImageResponse>(images);
        }
        public async Task<IReadOnlyCollection<GetImageResponse>> GetImagesByProductId(Guid Id)
        {
            var images = await _dbContext.ProductImages
                .Where(i => i.Product.Id == Id)
                .AsNoTracking()
                .Select(t => new GetImageResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    RelativeUrl = $"/uploads/{t.Name}{t.Extension}"
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
                    Name = t.Name,
                    RelativeUrl = $"/uploads/{t.Name}{t.Extension}",
                })
                .FirstOrDefaultAsync();

            return image;
        }

        //public async Task<AddImagesResponse> AddImages(Guid? productId, string key, string extension)
        //{
        //    var imageEntity = new ProductImage
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = key,
        //        Extension = extension,
        //    };

        //    if (productId != null)
        //    {
        //        var product = await _dbContext.Products
        //            .Include(p => p.Images)
        //            .FirstOrDefaultAsync(p => p.Id == productId);

        //        if (product != null)
        //        {
        //            product.Images ??= new List<ProductImage>();
        //            product.Images.Add(imageEntity);
        //            imageEntity.Product = product;
        //        }
        //    }

        //    _dbContext.ProductImages.Add(imageEntity);
        //    await _dbContext.SaveChangesAsync();

        //    return new AddImagesResponse
        //    {
        //        Id = imageEntity.Id,
        //        Name = imageEntity.Name,
        //        RelativeUrl = $"/uploads/{imageEntity.Name}{imageEntity.Extension}"
        //    };
        //}

        public async Task AddImagesBatch(List<ProductImage> images, Guid? productId)
        {
            if (images == null || images.Count == 0)
                return;
            if (productId != null)
            {
                var product = await _dbContext.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == productId);
                
                if (product != null)
                {
                    product.Images ??= new List<ProductImage>();
                    foreach (var image in images)
                    {
                        product.Images.Add(image);
                    }
                }
            }

            _dbContext.ProductImages.AddRange(images);

            await _dbContext.SaveChangesAsync(); 
        }


        public async Task<AddImageResponse> AddImage(Guid? productId, string key, string extension)
        {
            var imageEntity = new ProductImage
            {
                Id = Guid.NewGuid(),
                Name = key,
                Extension = extension,
            };

            if (productId != null)
            {
                var product = await _dbContext.Products
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.Id == productId);

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
                Name = imageEntity.Name,
                RelativeUrl = $"/uploads/{imageEntity.Name}{imageEntity.Extension}"
            };
        }

        public async Task<UpdateImageResponse?> UpdateImage(string key)
        {
            var image = await _dbContext.ProductImages
                .FirstOrDefaultAsync(t => t.Name == key);

            if (image == null)
                return null;

            image.Name = key;
            await _dbContext.SaveChangesAsync();

            return new UpdateImageResponse
            {
                ProductId = image.Product.Id,
                Name = image.Name,
                RelativeUrl = $"/uploads/{image.Name}{image.Extension}"
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
